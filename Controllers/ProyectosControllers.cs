using Microsoft.AspNetCore.Mvc;
using StudentsProyectsCRUD.Data;
using StudentsProyectsCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsProyectsCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProyectosController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
                return NotFound();

            return proyecto;
        }

        
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.Id)
                return BadRequest();

            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
                return NotFound();

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
