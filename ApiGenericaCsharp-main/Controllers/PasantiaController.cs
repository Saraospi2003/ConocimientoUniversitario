using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasantiaController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public PasantiaController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasantia>>> GetPasantias()
        {
            return await _context.Pasantias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pasantia>> GetPasantia(int id)
        {
            var pasantia = await _context.Pasantias.FindAsync(id);

            if (pasantia == null)
                return NotFound();

            return pasantia;
        }

        [HttpPost]
        public async Task<ActionResult<Pasantia>> PostPasantia(Pasantia pasantia)
        {
            _context.Pasantias.Add(pasantia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPasantia), new { id = pasantia.Id }, pasantia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasantia(int id, Pasantia pasantia)
        {
            if (id != pasantia.Id)
                return BadRequest();

            _context.Entry(pasantia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasantia(int id)
        {
            var pasantia = await _context.Pasantias.FindAsync(id);

            if (pasantia == null)
                return NotFound();

            _context.Pasantias.Remove(pasantia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}