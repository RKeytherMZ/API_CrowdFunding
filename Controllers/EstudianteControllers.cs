
using Microsoft.AspNetCore.Mvc;
using StudentsProyectsCRUD.Data;
using Microsoft.EntityFrameworkCore;
using StudentsProyectsCRUD.Models;

namespace CrowdfundingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> Get()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            return estudiante;
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> Post(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = estudiante.Id }, estudiante);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id) return BadRequest();
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
