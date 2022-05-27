using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class ArticulosRepository : IArticulos
    {
        private ApplicationDBContext _Db;

        public ArticulosRepository (ApplicationDBContext db) 
        { 
            _Db = db;
        }
        public void AddArticulo(Articulos ar)
        {
            _Db.Articulos.Add(ar);
            _Db.SaveChanges();
        }

        public void DeleteArticulo(Articulos ar)
        {
            _Db.Articulos.Remove(ar);
            _Db.SaveChanges();
        }

        public IEnumerable<Articulos> GetAll()
        {
            var Join = _Db.Articulos
                .Include(c => c.Categoria)
                .ToList();

            return Join;
        }

        public Articulos LoadArticulo(Articulos ar)
        {
            var listararticulo = _Db.Articulos.Where(x => x.ArticuloId == ar.ArticuloId).FirstOrDefault();
            return listararticulo;
        }

        public void UpdateAticulo(Articulos ar)
        {
            _Db.Articulos.Update(ar);
            _Db.SaveChanges();
        }
    }
}
