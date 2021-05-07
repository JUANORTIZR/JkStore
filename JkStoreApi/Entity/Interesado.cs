using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Interesado
    {
        [Key]
        public string Identificacion { get; set; }
        public string NumeroTelefonico { get; set; }
        [Required(ErrorMessage = "El primer nombre es requerido")]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es requerido")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "El segundo apellido es requerido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreDeUsuario { get; set; }
        [Required(ErrorMessage = "La Clave del usuario es requerida")]
        public string Clave { get; set; }
        [NotMapped]
        public List<Factura> Facturas { get; set; }
    }
}
