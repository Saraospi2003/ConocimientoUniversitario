using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteDepartamentoController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public DocenteDepartamentoController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocenteDepartamento>>> GetDocenteDepartamentos()
        {
            return await _context.DocenteDepartamentos.ToListAsync();
        }

        [HttpGet("{docente}/{departamento}")]
        public async Task<ActionResult<DocenteDepartamento>> GetDocenteDepartamento(int docente, int departamento)
        {
            var item = await _context.DocenteDepartamentos.FindAsync(docente, departamento);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<DocenteDepartamento>> PostDocenteDepartamento(DocenteDepartamento item)
        {
            _context.DocenteDepartamentos.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{docente}/{departamento}")]
        public async Task<IActionResult> DeleteDocenteDepartamento(int docente, int departamento)
        {
            var item = await _context.DocenteDepartamentos.FindAsync(docente, departamento);

            if (item == null)
                return NotFound();

            _context.DocenteDepartamentos.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}