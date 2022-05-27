using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class VentasRepository: IVentas
    {
        private ApplicationDBContext _db;
        public VentasRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public void AddVenta(Ventas ventas)
        {
            _db.Ventas.Add(ventas);
            _db.SaveChanges();
        }

        public void DeleteVenta(Ventas ventas)
        {
            _db.Ventas.Remove(ventas);
            _db.SaveChanges();
        }

        public IEnumerable<Ventas> GetAll()
        {
            var Join = _db.Ventas
                .Include(a => a.Articulo)
                .Include(c => c.Cliente)
                .Include(p => p.Pago)
                .Include(e => e.Empleado)
                .ToList();
            return Join;
        }

        public Ventas loadVenta(Ventas ventas)
        {
            var listarventa = _db.Ventas.Where(x => x.VentaId == ventas.VentaId).FirstOrDefault();
            return listarventa;

        }

        public void UpdateVenta(Ventas ventas)
        {
            _db.Ventas.Update(ventas);
            _db.SaveChanges();
        }
    }
}
