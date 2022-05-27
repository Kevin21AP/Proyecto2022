using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Repository
{
    public class EmpleadosRepository:IEmpleados
    {
        private ApplicationDBContext _Db;

        public EmpleadosRepository(ApplicationDBContext db)
        {
            _Db = db;
        }

        public void AddEmpleado(Empleados emp)
        {
            _Db.Empleados.Add(emp);
            _Db.SaveChanges();
        }

        public void DeleteEmpleado(Empleados emp)
        {
            _Db.Empleados.Remove(emp);
            _Db.SaveChanges();
        }

        public IEnumerable<Empleados> GetAll()
        {
            var Join = _Db.Empleados
                .Include(u => u.Usuario)
                .ToList();
            return Join;
        }

        public Empleados loadEmpleado(Empleados emp)
        {
            var listarEmpleado = _Db.Empleados.Where(x => x.EmpleadoId == emp.EmpleadoId).FirstOrDefault();
            return listarEmpleado;
        }

        public void UpdateEmpleado(Empleados emp)
        {
            _Db.Empleados.Update(emp);
            _Db.SaveChanges();
        }
    }
}
