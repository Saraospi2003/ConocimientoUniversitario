using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremioController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public PremioController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premio>>> GetPremios()
        {
            return await _context.Premios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Premio>> GetPremio(int id)
        {
            var premio = await _context.Premios.FindAsync(id);

            if (premio == null)
                return NotFound();

            return premio;
        }

        [HttpPost]
        public async Task<ActionResult<Premio>> PostPremio(Premio premio)
        {
            _context.Premios.Add(premio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPremio), new { id = premio.Id }, premio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremio(int id, Premio premio)
        {
            if (id != premio.Id)
                return BadRequest();

            _context.Entry(premio).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremio(int id)
        {
            var premio = await _context.Premios.FindAsync(id);

            if (premio == null)
                return NotFound();

            _context.Premios.Remove(premio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}