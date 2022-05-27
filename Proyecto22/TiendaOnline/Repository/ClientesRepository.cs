using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class ClientesRepository:IClientes
    {
        private ApplicationDBContext _Db;

        public ClientesRepository(ApplicationDBContext db)
        {
            _Db = db;
        }

        public void AddCliente(Clientes cli)
        {
            _Db.Clientes.Add(cli);
            _Db.SaveChanges();
        }

        public void DeleteCliente(Clientes cli)
        {
            _Db.Clientes.Remove(cli);
            _Db.SaveChanges();
        }

        public IEnumerable<Clientes> GetAll()
        {
            var Join = _Db.Clientes
                .Include(u => u.Usuario)
                .ToList();

            return Join;
        }

        public Clientes loadCliente(Clientes cli)
        {
            var listarcliente = _Db.Clientes.Where(x => x.ClienteId == cli.ClienteId).FirstOrDefault();
            return listarcliente;
        }

        public void UpdateCliente(Clientes cli)
        {
            _Db.Clientes.Update(cli);
            _Db.SaveChanges();
        }
    }
}
