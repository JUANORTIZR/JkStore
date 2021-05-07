using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FacturaConfig
{
    public class ConsultarFacturaResponse
    {
        public string Mensaje { get; set; }
        public List<Factura> Facturas { get; set; }
        public bool Error { get; set; }
        public ConsultarFacturaResponse(List<Factura> facturas)
        {
            Error = false;
            Facturas = facturas;
        }
        public ConsultarFacturaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
