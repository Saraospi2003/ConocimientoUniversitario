using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaConocimientoController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AreaConocimientoController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaConocimiento>>> GetAreaConocimientos()
        {
            return await _context.AreaConocimientos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaConocimiento>> GetAreaConocimiento(int id)
        {
            var areaConocimiento = await _context.AreaConocimientos.FindAsync(id);

            if (areaConocimiento == null)
                return NotFound();

            return areaConocimiento;
        }

        [HttpPost]
        public async Task<ActionResult<AreaConocimiento>> PostAreaConocimiento(AreaConocimiento areaConocimiento)
        {
            _context.AreaConocimientos.Add(areaConocimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAreaConocimiento), new { id = areaConocimiento.Id }, areaConocimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaConocimiento(int id, AreaConocimiento areaConocimiento)
        {
            if (id != areaConocimiento.Id)
                return BadRequest();

            _context.Entry(areaConocimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaConocimiento(int id)
        {
            var areaConocimiento = await _context.AreaConocimientos.FindAsync(id);

            if (areaConocimiento == null)
                return NotFound();

            _context.AreaConocimientos.Remove(areaConocimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}