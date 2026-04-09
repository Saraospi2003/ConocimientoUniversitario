using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfoqueController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public EnfoqueController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfoque>>> GetEnfoques()
        {
            return await _context.Set<Enfoque>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enfoque>> GetEnfoque(int id)
        {
            var enfoque = await _context.Set<Enfoque>().FindAsync(id);

            if (enfoque == null)
                return NotFound();

            return enfoque;
        }

        [HttpPost]
        public async Task<ActionResult<Enfoque>> PostEnfoque(Enfoque enfoque)
        {
            _context.Set<Enfoque>().Add(enfoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnfoque), new { id = enfoque.Id }, enfoque);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfoque(int id, Enfoque enfoque)
        {
            if (id != enfoque.Id)
                return BadRequest();

            _context.Entry(enfoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfoque(int id)
        {
            var enfoque = await _context.Set<Enfoque>().FindAsync(id);

            if (enfoque == null)
                return NotFound();

            _context.Set<Enfoque>().Remove(enfoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}