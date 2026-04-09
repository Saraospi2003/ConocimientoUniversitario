using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspectoNormativoController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AspectoNormativoController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspectoNormativo>>> GetAspectosNormativos()
        {
            return await _context.Set<AspectoNormativo>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AspectoNormativo>> GetAspectoNormativo(int id)
        {
            var aspecto = await _context.Set<AspectoNormativo>().FindAsync(id);

            if (aspecto == null)
                return NotFound();

            return aspecto;
        }

        [HttpPost]
        public async Task<ActionResult<AspectoNormativo>> PostAspectoNormativo(AspectoNormativo aspecto)
        {
            _context.Set<AspectoNormativo>().Add(aspecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAspectoNormativo), new { id = aspecto.Id }, aspecto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspectoNormativo(int id, AspectoNormativo aspecto)
        {
            if (id != aspecto.Id)
                return BadRequest();

            _context.Entry(aspecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspectoNormativo(int id)
        {
            var aspecto = await _context.Set<AspectoNormativo>().FindAsync(id);

            if (aspecto == null)
                return NotFound();

            _context.Set<AspectoNormativo>().Remove(aspecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}