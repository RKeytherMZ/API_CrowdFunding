using Microsoft.EntityFrameworkCore;
using StudentsProyectsCRUD.Models;



namespace StudentsProyectsCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Donacion> Donaciones { get; set; }
    }
}
