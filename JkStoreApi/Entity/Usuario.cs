using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entity
{
    public class Usuario
    {
        [Key]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "El primer nombre es requerido")]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es requerido")]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreDeUsuario { get; set; }
        [Required(ErrorMessage = "La clave es requerida")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El rol es requerido")]
        public string Rol { get; set; }
       
    }
}
