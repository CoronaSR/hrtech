using System.ComponentModel.DataAnnotations;

namespace HR_Tech.Models {
    public class LoginViewModelE {


        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Departamento es obligatorio.")]
        public string Departamento { get; set; }
    }
}
