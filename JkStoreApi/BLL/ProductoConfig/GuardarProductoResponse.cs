using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProductoConfig
{
    public class GuardarProductoResponse
    {
        public Producto Producto { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public GuardarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public GuardarProductoResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
    }
}
