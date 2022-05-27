using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
using Microsoft.AspNetCore.Session;
namespace TiendaOnline.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarios _user;
        private IClientes _cliente;

        private readonly ILogger<LoginController> _logger;
        private ApplicationDBContext _db;

        public LoginController(ILogger<LoginController> logger, IUsuarios user, IClientes cliente, ApplicationDBContext db)
        {
            _cliente = cliente;
            _user = user;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Alerta = TempData["alerta"];
            return View();
        }

        public IActionResult Registro()
        {

            return View();
        }

        public IActionResult Validar(Usuarios user)
        {
            var login = _user.Login(user.Correo, user.Clave);
            if (login != null)
            {
                if (login.Rol != "Admin")
                {
                    TempData["correo"] = login.Correo;
                    TempData["ID"] = login.UsuarioId;
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    TempData["correo"] = login.Correo;
                    TempData["ID"] = login.UsuarioId;
                    return RedirectToAction("Dasboard", "Admin");
                }

            }
            else
            {
                TempData["alerta"] = "Credenciales Incorretas!!";
                return RedirectToAction("Login");
            }

        }

        public IActionResult AddClient(Clientes cl)
        {
            cl.Usuario.Rol = "Cliente";
            
            _cliente.AddCliente(cl);
            return RedirectToAction("Login");
        }
    }
}
