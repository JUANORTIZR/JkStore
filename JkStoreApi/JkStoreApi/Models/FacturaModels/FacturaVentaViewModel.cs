using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkStoreApi.Models.FacturaModels
{
    public class FacturaVentaViewModel
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public Interesado Interesado { get; set; }
        public List<DetalleFactura> DetallesFactura { get; set; }
        public FacturaVentaViewModel(Factura factura)
        {
            Codigo = factura.Codigo;
            Fecha = factura.Fecha;
            Total = factura.Total;
            Interesado = factura.Interesado;
            DetallesFactura = factura.DetallesDeFactura;
        }
    }
}
