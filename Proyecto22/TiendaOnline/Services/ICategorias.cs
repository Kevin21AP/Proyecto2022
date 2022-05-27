using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface ICategorias
    {
        public void AddCategoria(Categorias cat);
        public void UpdateCategoria(Categorias cat);

        public void DeleteCategoria(Categorias cat);

        public List<Categorias> GetAll();

        public Categorias loadCategoria(Categorias cat);
    }
}
