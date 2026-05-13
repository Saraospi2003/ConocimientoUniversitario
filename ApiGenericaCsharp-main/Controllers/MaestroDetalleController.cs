using System.Data;
using System.Text.Json;
using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaestroDetalleController : ControllerBase
{
    private readonly BDUniversidadContext _context;

    public MaestroDetalleController(BDUniversidadContext context)
    {
        _context = context;
    }

    [HttpGet("programa-acreditaciones")]
    public async Task<IActionResult> ListarProgramasAcreditaciones()
    {
        var json = await EjecutarSpConResultado("sp_md_listar_programas_acreditaciones");

        return Content(json, "application/json");
    }

    [HttpGet("programa-acreditaciones/{id}")]
    public async Task<IActionResult> ConsultarProgramaAcreditaciones(int id)
    {
        var parametros = new List<SqlParameter>
        {
            new SqlParameter("@ProgramaId", id)
        };

        var json = await EjecutarSpConResultado("sp_md_consultar_programa_acreditaciones", parametros);

        return Content(json, "application/json");
    }

    [HttpPost("programa-acreditaciones")]
    public async Task<IActionResult> InsertarProgramaAcreditaciones([FromBody] ProgramaMaestroDetalleDto dto)
    {
        var parametros = CrearParametrosPrograma(dto);

        var json = await EjecutarSpConResultado("sp_md_insertar_programa_acreditaciones", parametros);

        return Content(json, "application/json");
    }

    [HttpPut("programa-acreditaciones/{id}")]
    public async Task<IActionResult> ActualizarProgramaAcreditaciones(int id, [FromBody] ProgramaMaestroDetalleDto dto)
    {
        dto.Id = id;

        var parametros = CrearParametrosPrograma(dto);

        var json = await EjecutarSpConResultado("sp_md_actualizar_programa_acreditaciones", parametros);

        return Content(json, "application/json");
    }

    [HttpDelete("programa-acreditaciones/{id}")]
    public async Task<IActionResult> BorrarProgramaAcreditaciones(int id)
    {
        var parametros = new List<SqlParameter>
        {
            new SqlParameter("@Id", id)
        };

        var json = await EjecutarSpConResultado("sp_md_borrar_programa_acreditaciones", parametros);

        return Content(json, "application/json");
    }

    private List<SqlParameter> CrearParametrosPrograma(ProgramaMaestroDetalleDto dto)
    {
        var acreditacionesJson = JsonSerializer.Serialize(dto.Acreditaciones);

        return new List<SqlParameter>
        {
            new SqlParameter("@Id", dto.Id),
            new SqlParameter("@Nombre", dto.Nombre ?? ""),
            new SqlParameter("@Tipo", dto.Tipo ?? ""),
            new SqlParameter("@Nivel", dto.Nivel ?? ""),
            new SqlParameter("@FechaCreacion", dto.FechaCreacion ?? (object)DBNull.Value),
            new SqlParameter("@FechaCierre", dto.FechaCierre ?? (object)DBNull.Value),
            new SqlParameter("@NumCohortes", dto.NumCohortes ?? (object)DBNull.Value),
            new SqlParameter("@CantGraduados", dto.CantGraduados ?? (object)DBNull.Value),
            new SqlParameter("@FechaActualizacion", dto.FechaActualizacion ?? (object)DBNull.Value),
            new SqlParameter("@Ciudad", dto.Ciudad ?? ""),
            new SqlParameter("@Facultad", dto.Facultad ?? (object)DBNull.Value),
            new SqlParameter("@Acreditaciones", acreditacionesJson)
        };
    }

    private async Task<string> EjecutarSpConResultado(string nombreSp, List<SqlParameter>? parametros = null)
    {
        var conexion = _context.Database.GetDbConnection();

        await conexion.OpenAsync();

        try
        {
            using var comando = conexion.CreateCommand();

            comando.CommandText = nombreSp;
            comando.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    comando.Parameters.Add(parametro);
                }
            }

            var resultadoParam = new SqlParameter("@Resultado", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            comando.Parameters.Add(resultadoParam);

            await comando.ExecuteNonQueryAsync();

            return resultadoParam.Value?.ToString() ?? "{}";
        }
        finally
        {
            await conexion.CloseAsync();
        }
    }
}