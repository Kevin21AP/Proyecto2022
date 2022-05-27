using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IProveedores
    {
        public void AddProveedor(Proveedores prov);
        public void UpdateProveedor(Proveedores prov);

        public void DeleteProveedor(Proveedores prov);

        public IEnumerable<Proveedores> GetAll();

        public Proveedores loadProveedor(Proveedores prov);

    }
}
