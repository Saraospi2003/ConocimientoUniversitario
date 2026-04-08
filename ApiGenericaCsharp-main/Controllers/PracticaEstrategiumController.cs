using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticaEstrategiumController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public PracticaEstrategiumController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticaEstrategium>>> GetPracticasEstrategia()
        {
            return await _context.Set<PracticaEstrategium>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PracticaEstrategium>> GetPracticaEstrategium(int id)
        {
            var practica = await _context.Set<PracticaEstrategium>().FindAsync(id);

            if (practica == null)
                return NotFound();

            return practica;
        }

        [HttpPost]
        public async Task<ActionResult<PracticaEstrategium>> PostPracticaEstrategium(PracticaEstrategium practica)
        {
            _context.Set<PracticaEstrategium>().Add(practica);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPracticaEstrategium), new { id = practica.Id }, practica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracticaEstrategium(int id, PracticaEstrategium practica)
        {
            if (id != practica.Id)
                return BadRequest();

            _context.Entry(practica).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracticaEstrategium(int id)
        {
            var practica = await _context.Set<PracticaEstrategium>().FindAsync(id);

            if (practica == null)
                return NotFound();

            _context.Set<PracticaEstrategium>().Remove(practica);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}