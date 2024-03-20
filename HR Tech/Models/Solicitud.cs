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
<<<<<<< HEAD
    }

    public class SolicitudViewModel
    {
        public string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int DiasSolicitados { get; set; }
        public string Departamento { get; set; }
=======
        public EstatusSolicitud Estatus { get; set; }
    }

    public enum EstatusSolicitud {
        APROBADA = 1,
        RECHAZADA = 2,
        ENVIADA = 3,
        EN_REVISION = 4,
>>>>>>> cd4e6f21fce655f094251b8d21d2096a4f400bb2
    }
}
