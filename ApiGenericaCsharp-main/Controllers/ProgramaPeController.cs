using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaPeController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public ProgramaPeController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaPe>>> GetProgramaPe()
        {
            return await _context.ProgramaPes.ToListAsync();
        }

        [HttpGet("{programa}/{practicaEstrategia}")]
        public async Task<ActionResult<ProgramaPe>> GetProgramaPe(int programa, int practicaEstrategia)
        {
            var item = await _context.ProgramaPes.FindAsync(programa, practicaEstrategia);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ProgramaPe>> PostProgramaPe(ProgramaPe item)
        {
            _context.ProgramaPes.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{programa}/{practicaEstrategia}")]
        public async Task<IActionResult> DeleteProgramaPe(int programa, int practicaEstrategia)
        {
            var item = await _context.ProgramaPes.FindAsync(programa, practicaEstrategia);

            if (item == null)
                return NotFound();

            _context.ProgramaPes.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}