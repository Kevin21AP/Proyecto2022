using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class ComprasRepository:ICompras
    {
        private ApplicationDBContext _Db;

        public ComprasRepository(ApplicationDBContext db)
        {
            _Db = db;
        }

        public void AddCompra(Compras comp)
        {
            _Db.Compras.Add(comp);
            _Db.SaveChanges();
        }

        public void DeleteCompra(Compras comp)
        {
            _Db.Compras.Remove(comp);
            _Db.SaveChanges();
        }

        public IEnumerable<Compras> GetAll()
        {
            var Join = _Db.Compras
               .Include(a => a.Articulo)
               .Include(p => p.Proveedor)
               .Include(e => e.Empleado)
               .ToList();

            return Join;
        }

        public Compras loadCompra(Compras comp)
        {
            var listarcompra = _Db.Compras.Where(x => x.CompraId == comp.CompraId).FirstOrDefault();
            return listarcompra;
        }

        public void UpdateCompra(Compras comp)
        {
            _Db.Compras.Update(comp);
            _Db.SaveChanges();
        }
    }
}
