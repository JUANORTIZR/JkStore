using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proveedor
    {
        [Key]
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string PaginaWeb { get; set; }
        [NotMapped]
        public List<Producto> Productos { get; set; }
    }
}
