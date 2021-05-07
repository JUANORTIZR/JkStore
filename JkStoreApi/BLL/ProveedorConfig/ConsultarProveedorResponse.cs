using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProveedorConfig
{
    public class ConsultarProveedorResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public ConsultarProveedorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public ConsultarProveedorResponse(List<Proveedor> proveedores)
        {
            Error = false;
            Proveedores = proveedores;
        }
    }
}
