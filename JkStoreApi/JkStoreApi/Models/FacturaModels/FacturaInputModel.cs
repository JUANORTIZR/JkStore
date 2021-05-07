using Entity;
using JkStoreApi.Models.DetalleFacturasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkStoreApi.Models.FacturaModels
{
    public class FacturaInputModel
    {
        public Proveedor Proveedor { get; set; }
        public string IdInteresado { get; set; }
        public string IdVendedor { get; set; }
        public List<DetalleInputModel> detallesDeFactura { get; set; }
    }
}
