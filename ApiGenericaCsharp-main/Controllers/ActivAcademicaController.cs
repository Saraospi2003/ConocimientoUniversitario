using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivAcademicaController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public ActivAcademicaController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivAcademica>>> GetActivAcademicas()
        {
            return await _context.ActivAcademicas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivAcademica>> GetActivAcademica(int id)
        {
            var actividad = await _context.ActivAcademicas.FindAsync(id);

            if (actividad == null)
                return NotFound();

            return actividad;
        }

        [HttpPost]
        public async Task<ActionResult<ActivAcademica>> PostActivAcademica(ActivAcademica actividad)
        {
            _context.ActivAcademicas.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivAcademica), new { id = actividad.Id }, actividad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivAcademica(int id, ActivAcademica actividad)
        {
            if (id != actividad.Id)
                return BadRequest();

            _context.Entry(actividad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivAcademica(int id)
        {
            var actividad = await _context.ActivAcademicas.FindAsync(id);

            if (actividad == null)
                return NotFound();

            _context.ActivAcademicas.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}