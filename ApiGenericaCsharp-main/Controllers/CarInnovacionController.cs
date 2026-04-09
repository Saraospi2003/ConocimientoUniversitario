using ApiGenericaCsharp.Data;
using ApiGenericaCsharp.Modelos;
using ApiGenericaCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGenericaCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarInnovacionController : ControllerBase
    {
        private readonly BDUniversidadContext _context;

        public CarInnovacionController(BDUniversidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInnovacion>>> GetCarInnovaciones()
        {
            return await _context.Set<CarInnovacion>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarInnovacion>> GetCarInnovacion(int id)
        {
            var carInnovacion = await _context.Set<CarInnovacion>().FindAsync(id);

            if (carInnovacion == null)
                return NotFound();

            return carInnovacion;
        }

        [HttpPost]
        public async Task<ActionResult<CarInnovacion>> PostCarInnovacion(CarInnovacion carInnovacion)
        {
            _context.Set<CarInnovacion>().Add(carInnovacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarInnovacion), new { id = carInnovacion.Id }, carInnovacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInnovacion(int id, CarInnovacion carInnovacion)
        {
            if (id != carInnovacion.Id)
                return BadRequest();

            _context.Entry(carInnovacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInnovacion(int id)
        {
            var carInnovacion = await _context.Set<CarInnovacion>().FindAsync(id);

            if (carInnovacion == null)
                return NotFound();

            _context.Set<CarInnovacion>().Remove(carInnovacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}