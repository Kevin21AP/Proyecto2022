using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IArticulos
    {
        public void AddArticulo(Articulos ar);
        public void UpdateAticulo(Articulos ar);

        public void DeleteArticulo(Articulos ar);

        public IEnumerable<Articulos> GetAll();

        public Articulos LoadArticulo(Articulos ar);
        
        //comit

    }
}
