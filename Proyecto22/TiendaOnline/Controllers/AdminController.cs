using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace TiendaOnline.Controllers
{
    public class AdminController : Controller
    {
        private IArticulos _articulos;
        private IClientes _cl;
        private readonly ILogger<ClienteController> _logger;
        private ApplicationDBContext _db;

        public AdminController(ILogger<ClienteController> logger, IArticulos articulos, IClientes cl, ApplicationDBContext db)
        {
            _articulos = articulos;
            _cl = cl;
            _logger = logger;
            _db = db;
        }
        
        public IActionResult Dasboard()
        {
            var cliente = from Clientes in _db.Clientes
                               where Clientes.ClienteId == Clientes.ClienteId
                               select Clientes;

            var empleado = from Empleados in _db.Empleados
                               where Empleados.EmpleadoId == Empleados.EmpleadoId
                               select Empleados;

            var proveedor = from Proveedores in _db.Proveedores
                           where Proveedores.ProveedorId == Proveedores.ProveedorId
                            select Proveedores;

            var usuario = from Usuarios in _db.Usuarios
                           where Usuarios.UsuarioId == Usuarios.UsuarioId
                           select Usuarios;


            ViewBag.Clientes = cliente.Count();
            ViewBag.empleado = empleado.Count();
            ViewBag.proveedor = proveedor.Count();
            ViewBag.usuario = usuario.Count();

            return View();
        }
    }
}
