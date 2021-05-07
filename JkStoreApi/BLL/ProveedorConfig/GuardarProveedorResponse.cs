using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProveedorConfig
{
    public class GuardarProveedorResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Proveedor Proveedor { get; set; }

        public GuardarProveedorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public GuardarProveedorResponse(Proveedor proveedor)
        {
            Error = false;
            Proveedor = proveedor;
        }
    }
}
