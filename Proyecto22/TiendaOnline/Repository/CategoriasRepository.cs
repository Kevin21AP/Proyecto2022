using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
namespace TiendaOnline.Repository
{
    public class CategoriasRepository:ICategorias
    {
        private ApplicationDBContext _Db;

        public CategoriasRepository(ApplicationDBContext db)
        {
            _Db = db;
        }

        public void AddCategoria(Categorias cat)
        {
            _Db.Categorias.Add(cat);
            _Db.SaveChanges();
        }

        public void DeleteCategoria(Categorias cat)
        {
            _Db.Categorias.Remove(cat);
            _Db.SaveChanges();
        }

        public List<Categorias> GetAll()
        {
            return _Db.Categorias.ToList();
        }

        public Categorias loadCategoria(Categorias cat)
        {
            var listarcategoria = _Db.Categorias.Where(x => x.CategoriaId == cat.CategoriaId).FirstOrDefault();
            return listarcategoria;
        }

        public void UpdateCategoria(Categorias cat)
        {
            _Db.Categorias.Update(cat);
            _Db.SaveChanges();
        }
    }
}
