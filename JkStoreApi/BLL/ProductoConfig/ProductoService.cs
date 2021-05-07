using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProductoConfig
{
    public class ProductoService
    {
        private readonly JkStoreContext context;
        public ProductoService(JkStoreContext _context)
        {
            context = _context;
        }

       public ConsultarProductoResponse Consultar()
        {
            try
            {
                List<Producto> productos = context.Productos.ToList();
                return new ConsultarProductoResponse(productos);
            }
            catch (Exception e)
            {
                return new ConsultarProductoResponse(e.Message);
            }
        }
    }
}
