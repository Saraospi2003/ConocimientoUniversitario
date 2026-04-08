using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversidadController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public UniversidadController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidades()
        {
            return await _context.Set<Universidad>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            var universidad = await _context.Set<Universidad>().FindAsync(id);

            if (universidad == null)
                return NotFound();

            return universidad;
        }

        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Set<Universidad>().Add(universidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUniversidad), new { id = universidad.Id }, universidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            if (id != universidad.Id)
                return BadRequest();

            _context.Entry(universidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversidad(int id)
        {
            var universidad = await _context.Set<Universidad>().FindAsync(id);

            if (universidad == null)
                return NotFound();

            _context.Set<Universidad>().Remove(universidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}