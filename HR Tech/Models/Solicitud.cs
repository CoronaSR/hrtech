using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Tech.Models {
    public class Solicitud {
        [Key]
        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public required string Descripcion { get; set; }
        public int DiasSolicitados { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public EstatusSolicitud Estatus { get; set; }
    }

    public class SolicitudViewModel
    {
        public string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int DiasSolicitados { get; set; }
        public string Departamento { get; set; }

    }

    public enum EstatusSolicitud {
        APROBADA = 1,
        RECHAZADA = 2,
        ENVIADA = 3,
        EN_REVISION = 4,

    }
}
