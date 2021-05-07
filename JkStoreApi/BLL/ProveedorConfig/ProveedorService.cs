using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProveedorConfig
{
    public class ProveedorService
    {
        private readonly JkStoreContext context;
        public ProveedorService(JkStoreContext _context)
        {
            context = _context;
        }

        public GuardarProveedorResponse Guardar(Proveedor proveedor)
        {
            try
            {
                Proveedor proveedorEncontrado = context.Proveedores.Find(proveedor.Nit);
                if (proveedorEncontrado != null) return new GuardarProveedorResponse($"El proveedor con el numero de id {proveedor.Nit}");

                context.Proveedores.Add(proveedor);
                context.SaveChanges();
                return new GuardarProveedorResponse(proveedor);
            }
            catch (Exception e)
            {
                return new GuardarProveedorResponse(e.Message);
            }
        }

        public ConsultarProveedorResponse Consultar()
        {
            try
            {
                List<Proveedor> proveedores = context.Proveedores.ToList();
                foreach (var item in proveedores)
                {
                    item.Productos = context.Productos.Where(p => p.IdProveedor == item.Nit).ToList();
                }
                return new ConsultarProveedorResponse(proveedores);
            }
            catch (Exception e)
            {
                return new ConsultarProveedorResponse(e.Message);
            }
        }
    }
}
