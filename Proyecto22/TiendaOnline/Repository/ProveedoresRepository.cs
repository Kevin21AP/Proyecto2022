using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class ProveedoresRepository: IProveedores
    {
        private ApplicationDBContext _db;
        public ProveedoresRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public void AddProveedor(Proveedores prov)
        {
            _db.Proveedores.Add(prov);  
            _db.SaveChanges();  
        }

        public void DeleteProveedor(Proveedores prov)
        {
            _db.Proveedores.Remove(prov);
            _db.SaveChanges();
        }

        public IEnumerable<Proveedores> GetAll()
        {
           var Join = _db.Proveedores
                .ToList();  
            return Join;
        }

        public Proveedores loadProveedor(Proveedores prov)
        {
            var listarProveedor = _db.Proveedores.Where(x => x.ProveedorId == prov.ProveedorId).FirstOrDefault();
            return listarProveedor;

        }

        public void UpdateProveedor(Proveedores prov)
        {
            _db.Proveedores.Update(prov);
            _db.SaveChanges();
        }
    }
}
