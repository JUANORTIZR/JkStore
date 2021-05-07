using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El nombre del detalle es requerido")]
        public string Nombre { get; set; }
        [NotMapped]
        public Producto _Producto { get; set; }
        public float Descuento { get; set; }
        public float ValorUnitario { get; set; }
        public int Cantidad { get; set; }
        public float Iva { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }

        public DetalleFactura()
        {

        }

        public DetalleFactura(Producto producto, float valorUnitario, int cantidad)
        {
            _Producto = producto;
            Nombre = producto.Nombre;
            ValorUnitario = valorUnitario;
            Cantidad = cantidad;
            SubTotal = ValorUnitario * Cantidad;
            Descuento = CalcularDescuento(producto.Descuento);
            Iva = CalcularIva(producto.Iva);
            CalcularTotal();
            
        }
        
        public float CalcularDescuento(float porcentajeDescuento)
        {
            return SubTotal * (porcentajeDescuento / 100);
        }

        public float CalcularIva(float porcentajeIva)
        {
            return SubTotal * (porcentajeIva / 100);
        }

        public void CalcularTotal()
        {
            Total = SubTotal + Iva - Descuento;
        }

    }
}
