using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcreditacionController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AcreditacionController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acreditacion>>> GetAcreditaciones()
        {
            return await _context.Acreditacions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Acreditacion>> GetAcreditacion(int id)
        {
            var acreditacion = await _context.Acreditacions.FindAsync(id);

            if (acreditacion == null)
                return NotFound();

            return acreditacion;
        }

        [HttpPost]
        public async Task<ActionResult<Acreditacion>> PostAcreditacion(Acreditacion acreditacion)
        {
            _context.Acreditacions.Add(acreditacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAcreditacion), new { id = acreditacion.Resolucion }, acreditacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcreditacion(int id, Acreditacion acreditacion)
        {
            if (id != acreditacion.Resolucion)
                return BadRequest();

            _context.Entry(acreditacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcreditacion(int id)
        {
            var acreditacion = await _context.Acreditacions.FindAsync(id);

            if (acreditacion == null)
                return NotFound();

            _context.Acreditacions.Remove(acreditacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}