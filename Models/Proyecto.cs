using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsProyectsCRUD.Models
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal MetaFinanciera { get; set; } 

        public decimal MontoRecaudado { get; set; } = 0; 

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        
        [ForeignKey("Estudiante")]
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}
