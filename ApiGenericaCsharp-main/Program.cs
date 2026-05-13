// Program.cs - Punto de entrada de la API Genérica
// Configuración de servicios, inyección de dependencias y middleware

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiGenericaCsharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// CONFIGURACIÓN
// ---------------------------------------------------------

builder.Configuration.AddJsonFile(
    "tablasprohibidas.json",
    optional: true,
    reloadOnChange: true
);

// ---------------------------------------------------------
// SERVICIOS
// ---------------------------------------------------------

builder.Services.AddControllers();

// Servicio para enviar correos
builder.Services.AddScoped<CorreoService>();

builder.Services.AddDbContext<BDUniversidadContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// CORS
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("PermitirTodo", politica => politica
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

// Sesión
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(opciones =>
{
    opciones.IdleTimeout = TimeSpan.FromMinutes(30);
    opciones.Cookie.HttpOnly = true;
    opciones.Cookie.IsEssential = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opciones =>
{
    opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Genérica CRUD Multi-Base de Datos",
        Version = "v1",
        Description = "API REST genérica para operaciones CRUD sobre cualquier tabla. Soporta SQL Server, PostgreSQL, MySQL/MariaDB. Incluye autenticación JWT."
    });

    var esquemaSeguridad = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese el token con el prefijo 'Bearer'. Ejemplo: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
    };

    opciones.AddSecurityDefinition("Bearer", esquemaSeguridad);

    opciones.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// -----------------------------------------------------------------
// REGISTRO DE SERVICIOS DEL PROYECTO
// -----------------------------------------------------------------

builder.Services.AddSingleton<
    ApiGenericaCsharp.Servicios.Abstracciones.IPoliticaTablasProhibidas,
    ApiGenericaCsharp.Servicios.Politicas.PoliticaTablasProhibidasDesdeJson>();

builder.Services.AddScoped<
    ApiGenericaCsharp.Servicios.Abstracciones.IServicioCrud,
    ApiGenericaCsharp.Servicios.ServicioCrud>();

builder.Services.AddSingleton<
    ApiGenericaCsharp.Servicios.Abstracciones.IProveedorConexion,
    ApiGenericaCsharp.Servicios.Conexion.ProveedorConexion>();

var proveedorBD = builder.Configuration.GetValue<string>("DatabaseProvider") ?? "SqlServer";

builder.Services.AddScoped<
    ApiGenericaCsharp.Servicios.Abstracciones.IServicioConsultas,
    ApiGenericaCsharp.Servicios.ServicioConsultas>();

switch (proveedorBD.ToLower())
{
    case "postgres":
        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioLecturaTabla,
            ApiGenericaCsharp.Repositorios.RepositorioLecturaPostgreSQL>();

        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioConsultas,
            ApiGenericaCsharp.Repositorios.RepositorioConsultasPostgreSQL>();
        break;

    case "mariadb":
    case "mysql":
        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioLecturaTabla,
            ApiGenericaCsharp.Repositorios.RepositorioLecturaMysqlMariaDB>();

        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioConsultas,
            ApiGenericaCsharp.Repositorios.RepositorioConsultasMysqlMariaDB>();
        break;

    case "sqlserver":
    case "sqlserverexpress":
    case "localdb":
    default:
        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioLecturaTabla,
            ApiGenericaCsharp.Repositorios.RepositorioLecturaSqlServer>();

        builder.Services.AddScoped<
            ApiGenericaCsharp.Repositorios.Abstracciones.IRepositorioConsultas,
            ApiGenericaCsharp.Repositorios.RepositorioConsultasSqlServer>();
        break;
}

// ---------------------------------------------------------
// CONFIGURACIÓN JWT
// ---------------------------------------------------------

builder.Services.Configure<ConfiguracionJwt>(
    builder.Configuration.GetSection("Jwt")
);

var configuracionJwt = new ConfiguracionJwt();
builder.Configuration.GetSection("Jwt").Bind(configuracionJwt);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opciones =>
    {
        opciones.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuracionJwt.Issuer,
            ValidAudience = configuracionJwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuracionJwt.Key)
            )
        };
    });

// ---------------------------------------------------------
// CONSTRUCCIÓN DE LA APP
// ---------------------------------------------------------

var app = builder.Build();

// ---------------------------------------------------------
// MIDDLEWARE
// ---------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGenericaCsharp v1");
    c.RoutePrefix = "swagger";
});

app.UseReDoc(c =>
{
    c.RoutePrefix = "redoc";
    c.SpecUrl("/swagger/v1/swagger.json");
});

//app.UseHttpsRedirection();

app.UseCors("PermitirTodo");

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();