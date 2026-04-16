using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfoqueRcController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public EnfoqueRcController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnfoqueRc>>> GetEnfoqueRc()
        {
            return await _context.EnfoqueRcs.ToListAsync();
        }

        [HttpGet("{enfoque}/{registroCalificado}")]
        public async Task<ActionResult<EnfoqueRc>> GetEnfoqueRc(int enfoque, int registroCalificado)
        {
            var item = await _context.EnfoqueRcs.FindAsync(enfoque, registroCalificado);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<EnfoqueRc>> PostEnfoqueRc(EnfoqueRc item)
        {
            _context.EnfoqueRcs.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{enfoque}/{registroCalificado}")]
        public async Task<IActionResult> DeleteEnfoqueRc(int enfoque, int registroCalificado)
        {
            var item = await _context.EnfoqueRcs.FindAsync(enfoque, registroCalificado);

            if (item == null)
                return NotFound();

            _context.EnfoqueRcs.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}