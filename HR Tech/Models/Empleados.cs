using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HR_Tech.Models {
    public class Empleados {
        [Key]
        public int IdEmpleado { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Puesto { get; set; }
        public required string Departamento { get; set; }
        public int DiasDeVacaciones { get; set; }
        public ICollection<Solicitud>? Solicitudes { get; set; }
    }
}
