using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.DTOs;
using ApiGenericaCsharp.Models;
using ApiGenericaCsharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BDUniversidadContext _context;
        private readonly CorreoService _correoService;

        public AuthController(BDUniversidadContext context, CorreoService correoService)
        {
            _context = context;
            _correoService = correoService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro(RegistroDto dto)
        {
            var existe = await _context.Usuarios
                .AnyAsync(u => u.Correo == dto.Correo);

            if (existe)
            {
                return BadRequest(new
                {
                    mensaje = "El correo ya está registrado"
                });
            }

            if (dto.Rol != "Administrador" &&
                dto.Rol != "Docente" &&
                dto.Rol != "Consultor")
            {
                return BadRequest(new
                {
                    mensaje = "Rol no válido"
                });
            }

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = dto.Password,
                Rol = dto.Rol
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Usuario registrado correctamente",
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                usuario.Rol
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Correo == dto.Correo &&
                    u.Password == dto.Password);

            if (usuario == null)
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos"
                });
            }

            return Ok(new
            {
                mensaje = "Inicio de sesión exitoso",
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                usuario.Rol
            });
        }

        [HttpPut("cambiar-password")]
        public async Task<IActionResult> CambiarPassword(CambiarPasswordDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Correo == dto.Correo &&
                    u.Password == dto.PasswordActual);

            if (usuario == null)
            {
                return BadRequest(new
                {
                    mensaje = "Correo o contraseña actual incorrecta"
                });
            }

            usuario.Password = dto.PasswordNueva;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Contraseña actualizada correctamente"
            });
        }

        [HttpPost("enviar-codigo")]
        public async Task<IActionResult> EnviarCodigo(string correo)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo);

            if (usuario == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado"
                });
            }

            var codigo = new Random()
                .Next(100000, 999999)
                .ToString();

            usuario.CodigoRecuperacion = codigo;
            usuario.ExpiracionCodigo = DateTime.Now.AddMinutes(10);

            await _context.SaveChangesAsync();

            await _correoService.EnviarCodigo(correo, codigo);

            return Ok(new
            {
                mensaje = "Código enviado al correo"
            });
        }

        [HttpPut("recuperar-password")]
        public async Task<IActionResult> RecuperarPassword(RecuperarPasswordDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Correo == dto.Correo &&
                    u.CodigoRecuperacion == dto.Codigo);

            if (usuario == null)
            {
                return BadRequest(new
                {
                    mensaje = "Código incorrecto"
                });
            }

            if (usuario.ExpiracionCodigo < DateTime.Now)
            {
                return BadRequest(new
                {
                    mensaje = "Código expirado"
                });
            }

            usuario.Password = dto.NuevaPassword;
            usuario.CodigoRecuperacion = null;
            usuario.ExpiracionCodigo = null;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Contraseña actualizada correctamente"
            });
        }
    }
}