using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsProyectsCRUD.Data;
using StudentsProyectsCRUD.Models;

namespace StudentsProyectsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonacionesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donacion>>> GetDonaciones()
        {
            return await _context.Donaciones.Include(d => d.Proyecto).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> GetDonacion(int id)
        {
            var donacion = await _context.Donaciones.Include(d => d.Proyecto)
                                                    .FirstOrDefaultAsync(d => d.Id == id);

            if (donacion == null)
            {
                return NotFound();
            }

            return donacion;
        }

        
        [HttpPost]
        public async Task<ActionResult<Donacion>> PostDonacion(Donacion donacion)
        {
            _context.Donaciones.Add(donacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacion", new { id = donacion.Id }, donacion);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacion(int id, Donacion donacion)
        {
            if (id != donacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(donacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacion(int id)
        {
            var donacion = await _context.Donaciones.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            _context.Donaciones.Remove(donacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionExists(int id)
        {
            return _context.Donaciones.Any(e => e.Id == id);
        }
    }
}
