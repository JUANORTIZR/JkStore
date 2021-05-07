using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class JkStoreContext : DbContext
    {
        public JkStoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Interesado> Interesados { get; set; }

    }
}
