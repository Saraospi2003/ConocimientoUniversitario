using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaCiController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public ProgramaCiController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaCi>>> GetProgramaCi()
        {
            return await _context.ProgramaCis.ToListAsync();
        }

        [HttpGet("{programa}/{carInnovacion}")]
        public async Task<ActionResult<ProgramaCi>> GetProgramaCi(int programa, int carInnovacion)
        {
            var item = await _context.ProgramaCis.FindAsync(programa, carInnovacion);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ProgramaCi>> PostProgramaCi(ProgramaCi item)
        {
            _context.ProgramaCis.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{programa}/{carInnovacion}")]
        public async Task<IActionResult> DeleteProgramaCi(int programa, int carInnovacion)
        {
            var item = await _context.ProgramaCis.FindAsync(programa, carInnovacion);

            if (item == null)
                return NotFound();

            _context.ProgramaCis.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}