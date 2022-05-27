using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class PagosRepository : IPagos
    {
        private ApplicationDBContext _db;
        public PagosRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public void AddPago(Pagos pagos)
        {
           _db.Pagos.Add(pagos);
           _db.SaveChanges();

        }

        public void DeletePago(Pagos pagos)
        {
            _db.Pagos.Remove(pagos);
            _db.SaveChanges();
        }

        public List<Pagos> GetAll()
        {
            return _db.Pagos.ToList();
        }

        public Pagos loadPago(Pagos pagos)
        {
            var listarpago = _db.Pagos.Where(x => x.PagoId == pagos.PagoId).FirstOrDefault();
            return listarpago;  
        }

        public void UpdatePago(Pagos pagos)
        {
            _db.Pagos.Update(pagos);
            _db.SaveChanges();
        }
    }
}
