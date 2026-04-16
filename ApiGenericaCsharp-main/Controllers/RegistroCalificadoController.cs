using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroCalificadoController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public RegistroCalificadoController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroCalificado>>> GetRegistroCalificados()
        {
            return await _context.RegistroCalificados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroCalificado>> GetRegistroCalificado(int id)
        {
            var registro = await _context.RegistroCalificados.FindAsync(id);

            if (registro == null)
                return NotFound();

            return registro;
        }

        [HttpPost]
        public async Task<ActionResult<RegistroCalificado>> PostRegistroCalificado(RegistroCalificado registro)
        {
            _context.RegistroCalificados.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistroCalificado), new { id = registro.Codigo }, registro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroCalificado(int id, RegistroCalificado registro)
        {
            if (id != registro.Codigo)
                return BadRequest();

            _context.Entry(registro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroCalificado(int id)
        {
            var registro = await _context.RegistroCalificados.FindAsync(id);

            if (registro == null)
                return NotFound();

            _context.RegistroCalificados.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}