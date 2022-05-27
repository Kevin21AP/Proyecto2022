using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IClientes
    {
        public void AddCliente(Clientes cli);
        public void UpdateCliente(Clientes cli);

        public void DeleteCliente(Clientes cli);

        public IEnumerable<Clientes> GetAll();

        public Clientes loadCliente(Clientes cli);
    }
}
