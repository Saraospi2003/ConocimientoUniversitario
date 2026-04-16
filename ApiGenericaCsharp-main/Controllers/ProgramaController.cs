using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public ProgramaController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programa>>> GetProgramas()
        {
            return await _context.Programas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programa>> GetPrograma(int id)
        {
            var programa = await _context.Programas.FindAsync(id);

            if (programa == null)
                return NotFound();

            return programa;
        }

        [HttpPost]
        public async Task<ActionResult<Programa>> PostPrograma(Programa programa)
        {
            _context.Programas.Add(programa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrograma), new { id = programa.Id }, programa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrograma(int id, Programa programa)
        {
            if (id != programa.Id)
                return BadRequest();

            _context.Entry(programa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrograma(int id)
        {
            var programa = await _context.Programas.FindAsync(id);

            if (programa == null)
                return NotFound();

            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}