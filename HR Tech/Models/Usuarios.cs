using System.ComponentModel.DataAnnotations;

namespace HR_Tech.Models {
    public class Usuarios {
        [Key]
        public int IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Puesto { get; set; }
        public required string Departamento { get; set; }
        public required string Usuario { get; set; }
        public required string Password { get; set; }
    }
}
