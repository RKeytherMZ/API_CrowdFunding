using System.ComponentModel.DataAnnotations;

namespace StudentsProyectsCRUD.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        public string Carrera { get; set; }

        public string Institucion { get; set; }
    }
}
    

