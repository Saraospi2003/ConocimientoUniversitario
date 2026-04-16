using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaAcController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public ProgramaAcController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaAc>>> GetProgramaAc()
        {
            return await _context.ProgramaAcs.ToListAsync();
        }

        [HttpGet("{programa}/{areaConocimiento}")]
        public async Task<ActionResult<ProgramaAc>> GetProgramaAc(int programa, int areaConocimiento)
        {
            var item = await _context.ProgramaAcs.FindAsync(programa, areaConocimiento);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ProgramaAc>> PostProgramaAc(ProgramaAc item)
        {
            _context.ProgramaAcs.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{programa}/{areaConocimiento}")]
        public async Task<IActionResult> DeleteProgramaAc(int programa, int areaConocimiento)
        {
            var item = await _context.ProgramaAcs.FindAsync(programa, areaConocimiento);

            if (item == null)
                return NotFound();

            _context.ProgramaAcs.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}