using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public FacultadController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultades()
        {
            return await _context.Facultads.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
            var facultad = await _context.Facultads.FindAsync(id);

            if (facultad == null)
                return NotFound();

            return facultad;
        }

        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad facultad)
        {
            _context.Facultads.Add(facultad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacultad), new { id = facultad.Id }, facultad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultad(int id, Facultad facultad)
        {
            if (id != facultad.Id)
                return BadRequest();

            _context.Entry(facultad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultad(int id)
        {
            var facultad = await _context.Facultads.FindAsync(id);

            if (facultad == null)
                return NotFound();

            _context.Facultads.Remove(facultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}