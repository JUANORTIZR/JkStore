using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FacturaConfig
{
    public class GuardarFacturaResponse
    {
        public Factura Factura { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public GuardarFacturaResponse(Factura factura)
        {
            Error = false;
            Factura = factura;
        }
        public GuardarFacturaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
