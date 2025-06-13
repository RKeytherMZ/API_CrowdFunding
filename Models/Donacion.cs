using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsProyectsCRUD.Models
{
    public class Donacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Donante { get; set; } 

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
