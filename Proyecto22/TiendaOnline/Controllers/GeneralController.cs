using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Controllers
{
    public class GeneralController : Controller
    {
        private IClientes _cliente;
        private IEmpleados _empleado;
        private IUsuarios _user;
     

        private readonly ILogger<GeneralController> _logger;
        private ApplicationDBContext _db;

        public GeneralController(ILogger<GeneralController> logger, IClientes cliente, IEmpleados empleado,
           IUsuarios usuario, ApplicationDBContext db)
        {
            _cliente= cliente;
            _empleado= empleado;
            _user= usuario;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cliente()
        {

            var cliente = _db.Clientes
               
               .Include(u => u.Usuario)
               .ToList();

            Clientes clientes = new Clientes();
            ViewBag.usuario = _db.Usuarios.ToList();
            
            ViewBag.compra = cliente;
            return View(clientes);
        }

        public IActionResult GuardarCliente(Clientes client)
        {

            _cliente.UpdateCliente(client);
            return RedirectToAction("Cliente");
        }

        public IActionResult EditCliente(int id)
        {
            Clientes client = new Clientes();
            client.ClienteId = id;
            var list = _cliente.loadCliente(client);

            ViewBag.usuario = _db.Usuarios.ToList();

            return View(list);
        }

        public IActionResult ActualizarCliente(Clientes cliente)
        {
            _cliente.UpdateCliente(cliente);

            return RedirectToAction("Cliente");
        }

        public IActionResult DeleteCliente(int id)
        {
            Clientes client = new Clientes();
            client.ClienteId= id;
            _cliente.DeleteCliente(client); 
            return RedirectToAction("Cliente");
        }

        // ************************************ USUARIOS ***********************************************


        public IActionResult Usuario()
        {
            ViewBag.usuario = _user.GetAll();

            return View();
        }

        public IActionResult GuardarUsuario(Usuarios user)
        {

            _user.UpdateUsuario(user);
            return RedirectToAction("Usuario");
        }

        public IActionResult EditUsuario(int id)
        {
            Usuarios user = new Usuarios();
            user.UsuarioId = id;
            var list = _user.loadUsuario(user);
            return View(list);
        }

        public IActionResult ActualizarUsuario(Usuarios us)
        {
            _user.UpdateUsuario(us);
            return RedirectToAction("Usuario");
        }

        public IActionResult DeleteUsuario(int id)
        {
            Usuarios us = new Usuarios();
            us.UsuarioId = id;
            _user.DeleteUsuario(us);
            return RedirectToAction("Usuario");
        }

        // ************************************ Emlpeado **********************************************88


        public IActionResult Empleado()
        {
            var empleado = _db.Empleados

               .Include(u => u.Usuario)
               .ToList();

            Empleados empleados = new Empleados();
            ViewBag.usuario = _db.Usuarios.ToList();

            ViewBag.empleado = empleado;
            return View(empleados);
        }

        public IActionResult GuardarEmpleado(Empleados emp)
        {

            _empleado.UpdateEmpleado(emp);
            return RedirectToAction("Empleado");
        }

        public IActionResult EditEmpleado(int id)
        {
            Empleados empl = new Empleados();
            empl.EmpleadoId = id;
            var list = _empleado.loadEmpleado(empl);

            ViewBag.usuario = _db.Usuarios.ToList();

            return View(list);
        }

        public IActionResult ActualizarEmpleado(Empleados emp)
        {
            _empleado.UpdateEmpleado(emp);

            return RedirectToAction("Empleado");
        }

        public IActionResult DeleteEmpleado(int id)
        {
            Empleados empl = new Empleados();
            empl.EmpleadoId = id;
            _empleado.DeleteEmpleado(empl);
            return RedirectToAction("Empleado");
        }
    }
}
