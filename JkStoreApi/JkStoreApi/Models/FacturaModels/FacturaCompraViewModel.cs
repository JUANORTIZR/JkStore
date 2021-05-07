using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkStoreApi.Models.FacturaModels
{
    public class FacturaCompraViewModel
    {
        public int Codigo { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public List<DetalleFactura>  DetallesFactura { get; set; }

        public FacturaCompraViewModel(Factura factura)
        {
            Codigo = factura.Codigo;
            Proveedor = factura.Proveedor;
            Fecha = factura.Fecha;
            Total = factura.Total;
            DetallesFactura = factura.DetallesDeFactura;
        }

    }
}
