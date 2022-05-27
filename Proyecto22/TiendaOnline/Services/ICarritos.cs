using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface ICarritos
    {
        public void AddCarrito(Carritos car);
        public void UpdateCarrito(Carritos car);

        public void DeleteCarrito(Carritos car);

        public IEnumerable<Carritos> GetAll();

        public Carritos loadCarrito(Carritos car);
    }
}
