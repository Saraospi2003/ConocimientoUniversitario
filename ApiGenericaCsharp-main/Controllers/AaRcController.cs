using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AaRcController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public AaRcController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AaRc>>> GetAaRc()
        {
            return await _context.AaRcs.ToListAsync();
        }

        [HttpGet("{activAcademica}/{registroCalificado}")]
        public async Task<ActionResult<AaRc>> GetAaRc(int activAcademica, int registroCalificado)
        {
            var item = await _context.AaRcs.FindAsync(activAcademica, registroCalificado);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<AaRc>> PostAaRc(AaRc item)
        {
            _context.AaRcs.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{activAcademica}/{registroCalificado}")]
        public async Task<IActionResult> DeleteAaRc(int activAcademica, int registroCalificado)
        {
            var item = await _context.AaRcs.FindAsync(activAcademica, registroCalificado);

            if (item == null)
                return NotFound();

            _context.AaRcs.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}