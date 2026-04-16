using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnProgramaController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AnProgramaController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnPrograma>>> GetAnPrograma()
        {
            return await _context.AnProgramas.ToListAsync();
        }

        [HttpGet("{aspectoNormativo}/{programa}")]
        public async Task<ActionResult<AnPrograma>> GetAnPrograma(int aspectoNormativo, int programa)
        {
            var item = await _context.AnProgramas.FindAsync(aspectoNormativo, programa);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<AnPrograma>> PostAnPrograma(AnPrograma item)
        {
            _context.AnProgramas.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{aspectoNormativo}/{programa}")]
        public async Task<IActionResult> DeleteAnPrograma(int aspectoNormativo, int programa)
        {
            var item = await _context.AnProgramas.FindAsync(aspectoNormativo, programa);

            if (item == null)
                return NotFound();

            _context.AnProgramas.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}