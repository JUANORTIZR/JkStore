using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El total de l afactura es requerido")]
        public float Total { get; set; }
        [ForeignKey("IdProveedor")]
        public string NitProveedor { get; set; }
        [NotMapped]
        public Proveedor Proveedor { get; set; }
        [ForeignKey("IdInteresado")]
        public string IdInteresado { get; set; }
        [NotMapped]
        public Interesado Interesado { get; set; }
        [NotMapped]
        public Usuario Vendedor { get; set; }

        public List<DetalleFactura> DetallesDeFactura { get; set; }

        public Factura()
        {
            DetallesDeFactura = new List<DetalleFactura>();
            Fecha = DateTime.Now;
        }

        public void AgregarDetalle(Producto producto, float valorUnitario, float descuento,int cantidad)
        { 
            DetalleFactura detalleFactura = new DetalleFactura(producto, valorUnitario, descuento, cantidad);
            DetallesDeFactura.Add(detalleFactura); 
        }
        public void CalcularTotal()
        {
            Total = DetallesDeFactura.Sum(t => t.Total);
        }


    }
}
