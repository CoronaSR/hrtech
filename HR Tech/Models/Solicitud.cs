using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Tech.Models {
    public class Solicitud {
        [Key]
        public int IdSolicitud { get; set; }
        [ForeignKey(nameof(IdSolicitud))]
        public int IdEmpleado { get; set; }
        public required string Descripcion { get; set; }
        public int DiasSolicitados { get; set; }
        public DateTime FechaSolicitud { get; set; }

    }
}
