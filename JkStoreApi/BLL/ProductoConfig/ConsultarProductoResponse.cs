using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProductoConfig
{
    public class ConsultarProductoResponse
    {
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ConsultarProductoResponse(List<Producto> productos)
        {
            Error = false;
            Productos = productos;
        }

        public ConsultarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
