using Microsoft.EntityFrameworkCore;
using TiendaOnline.Models;

namespace TiendaOnline.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }
        public DbSet <Articulos> Articulos { get; set; }
        public DbSet<Carritos> Carritos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        //genera el codigo para la migracion de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)//al momento que se ejecuta crea la tabla
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
