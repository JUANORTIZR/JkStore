using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.FacturaConfig
{
    public class FacturaService
    {
        private readonly JkStoreContext context;
        public FacturaService(JkStoreContext _context)
        {
            context = _context;
        }

        public GuardarFacturaResponse Guardar(Factura factura, string evento)
        {
            try
            {           
                if (evento == "Compra")
                {
                    factura.DetallesDeFactura = new List<DetalleFactura>();
                    factura.IdInteresado = null;
                    Proveedor proveedor = context.Proveedores.Find(factura.Proveedor.Identificacion);
                    if(proveedor == null)
                    {
                        context.Proveedores.Add(factura.Proveedor);
                    }
                    factura.IdProveedor = factura.Proveedor.Identificacion;
                    foreach (var item in factura.Proveedor.Productos)
                    {
                        Producto producto = context.Productos.Find(item.Codigo);
                        if(producto == null)
                        {
                            context.Productos.Add(item);
                        }
                        else
                        {
                            producto.Existencias += item.Existencias;
                            context.Productos.Update(producto);
                        }
                        factura.AgregarDetalle(item, item.ValorUnitario, item.Existencias);
                    }
                }
                else if(evento == "Venta")
                {
                  
                    Interesado interesado = context.Interesados.Find(factura.IdInteresado);
                    if (interesado == null)
                    {
                        interesado = new Interesado();
                        interesado.PrimerNombre = "No registrado";
                        interesado.PrimerApellido = "No registrado";
                    }
                    factura.Interesado = interesado;
                    List<DetalleFactura> detalleFacturasTemp = factura.DetallesDeFactura;
                    factura.DetallesDeFactura = new List<DetalleFactura>();
                    foreach (var item in detalleFacturasTemp)
                    {
                        Producto producto = context.Productos.Find(item._Producto.Codigo);
                        if(producto == null)
                        {
                            return new GuardarFacturaResponse($"El producto con el id {item._Producto.Codigo} no existe");
                        }
                        if(producto.Existencias < item.Cantidad)
                        {
                            return new GuardarFacturaResponse($"Cantidad insuficiente para producto {producto.Nombre}, cantidad disponible {producto.Existencias}");
                        }
                        producto.Existencias -= item.Cantidad;
                        
                        context.Productos.Update(producto);
                        float valorUnitario;
                        if (item.ValorUnitario > 0)
                        {      
                            valorUnitario = item.ValorUnitario;
                        }
                        else
                        {
                            valorUnitario = producto.ValorUnitario;
                        }                     
                        factura.AgregarDetalle(producto, valorUnitario , item.Cantidad);
                    }
                }
              
                factura.CalcularTotal();
                context.Facturas.Add(factura);
                context.SaveChanges();
                return new GuardarFacturaResponse(factura);
            }
            catch (Exception e)
            {
                return new GuardarFacturaResponse(e.Message);
            }
            
        }

        public ConsultarFacturaResponse ConsultarVentas()
        {
            try
            {
                List<Factura> facturas = context.Facturas.Include(d => d.DetallesDeFactura).ToList();
                return new ConsultarFacturaResponse(facturas);
            }
            catch (Exception e)
            {
                return new ConsultarFacturaResponse(e.Message);
            }
        }

    }
}
