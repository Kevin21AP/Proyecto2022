using TiendaOnline.Models;

namespace TiendaOnline.Services
{
    public interface IPagos
    {
        public void AddPago(Pagos pagos);
        public void UpdatePago(Pagos pagos);

        public void DeletePago(Pagos pagos);

        public List<Pagos> GetAll();

        public Pagos loadPago(Pagos pagos);
    }
}
