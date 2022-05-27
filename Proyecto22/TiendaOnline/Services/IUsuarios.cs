using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IUsuarios
    {
        public void AddUsuario(Usuarios us);
        public void UpdateUsuario(Usuarios us);

        public void DeleteUsuario(Usuarios us);

        public List<Usuarios> GetAll();

        public Usuarios loadUsuario(Usuarios us);
    }
}
