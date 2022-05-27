using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IVentas
    {
        
        public void AddVenta(Ventas ventas);
        public void UpdateVenta(Ventas ventas);

        public void DeleteVenta(Ventas ventas);

        public IEnumerable<Ventas> GetAll();

        public Ventas loadVenta(Ventas ventas);


    }
}
