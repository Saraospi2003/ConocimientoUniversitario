using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public UsuariosController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return Ok(usuarios);
        }

        [HttpPut("cambiar-rol")]
        public async Task<IActionResult> CambiarRol(CambiarRolDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);

            if (usuario == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado"
                });
            }

            if (dto.NuevoRol != "Administrador" &&
                dto.NuevoRol != "Docente" &&
                dto.NuevoRol != "Consultor")
            {
                return BadRequest(new
                {
                    mensaje = "Rol no válido"
                });
            }

            usuario.Rol = dto.NuevoRol;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Rol actualizado correctamente",
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                usuario.Rol
            });
        }
    }
}