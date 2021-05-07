using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkStoreApi.Models.FacturaModels
{
    public class FacturaViewModel
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public string IdProveedor { get; set; }
        public string IdInteresado { get; set; }
        public List<DetalleFactura> DetallesFactura { get; set; }
        public FacturaViewModel(Factura factura)
        {
            Codigo = factura.Codigo;
            Fecha = factura.Fecha;
            Total = factura.Total;
            IdProveedor = factura.NitProveedor;
            IdInteresado = factura.IdInteresado;
            DetallesFactura = factura.DetallesDeFactura;
        }

    }
}
