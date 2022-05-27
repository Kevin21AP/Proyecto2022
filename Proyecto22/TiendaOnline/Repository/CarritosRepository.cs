using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
namespace TiendaOnline.Repository
{
    public class CarritosRepository : ICarritos
    {
        private ApplicationDBContext _Db;

        public CarritosRepository(ApplicationDBContext db)
        {
            _Db = db;
        }
        public void AddCarrito(Carritos car)
        {
            _Db.Carritos.Add(car);
            _Db.SaveChanges();
        }

        public void DeleteCarrito(Carritos car)
        {
            _Db.Carritos.Remove(car);
            _Db.SaveChanges();
        }

      
        public IEnumerable<Carritos> GetAll()
        {
            var Join = _Db.Carritos
               .Include(a => a.Articulo)
               //.Include(u => c.Usuario )
               .ToList();
            return Join;
        }

        public Carritos loadCarrito(Carritos car)
        {
            var listarcarrito = _Db.Carritos.Where(x => x.CarritoId == car.CarritoId).FirstOrDefault();
            return listarcarrito;
        }

        public void UpdateCarrito(Carritos car)
        {
            _Db.Carritos.Update(car);
            _Db.SaveChanges();
        }
    }
}
