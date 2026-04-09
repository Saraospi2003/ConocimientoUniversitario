using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliadoController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AliadoController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aliado>>> GetAliados()
        {
            return await _context.Set<Aliado>().ToListAsync();
        }

        [HttpGet("{nit}")]
        public async Task<ActionResult<Aliado>> GetAliado(long nit)
        {
            var aliado = await _context.Set<Aliado>().FindAsync(nit);

            if (aliado == null)
                return NotFound();

            return aliado;
        }

        [HttpPost]
        public async Task<ActionResult<Aliado>> PostAliado(Aliado aliado)
        {
            _context.Set<Aliado>().Add(aliado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAliado), new { nit = aliado.Nit }, aliado);
        }

        [HttpPut("{nit}")]
        public async Task<IActionResult> PutAliado(long nit, Aliado aliado)
        {
            if (nit != aliado.Nit)
                return BadRequest();

            _context.Entry(aliado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{nit}")]
        public async Task<IActionResult> DeleteAliado(long nit)
        {
            var aliado = await _context.Set<Aliado>().FindAsync(nit);

            if (aliado == null)
                return NotFound();

            _context.Set<Aliado>().Remove(aliado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}