using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlianzaController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AlianzaController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alianza>>> GetAlianzas()
        {
            return await _context.Alianzas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alianza>> GetAlianza(int id)
        {
            var alianza = await _context.Alianzas.FindAsync(id);

            if (alianza == null)
                return NotFound();

            return alianza;
        }

        [HttpPost]
        public async Task<ActionResult<Alianza>> PostAlianza(Alianza alianza)
        {
            _context.Alianzas.Add(alianza);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlianza), new { id = alianza.Id }, alianza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlianza(int id, Alianza alianza)
        {
            if (id != alianza.Id)
                return BadRequest();

            _context.Entry(alianza).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlianza(int id)
        {
            var alianza = await _context.Alianzas.FindAsync(id);

            if (alianza == null)
                return NotFound();

            _context.Alianzas.Remove(alianza);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}