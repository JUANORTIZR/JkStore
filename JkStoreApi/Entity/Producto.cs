using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El id del proveedor es requerido")]
        public string IdProveedor { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La categoria del producto es requerida")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "El valor unitario del producto es requerido")]
        public float ValorUnitario { get; set; }
        [Required(ErrorMessage = "El iva del producto es requerido")]
        public float Iva { get; set; }
        public float Descuento { get; set; }
        public int Existencias { get; set; }

    }
}
