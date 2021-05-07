using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkStoreApi.Models.DetalleFacturasModels
{
    public class DetalleInputModel
    {
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public float ValorUnitario { get; set; }
        public float Descuento { get; set; }
    }
}
