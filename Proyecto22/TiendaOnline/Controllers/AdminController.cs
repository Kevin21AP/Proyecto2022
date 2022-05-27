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
        //public IActionResult Index()
        //{
        //    var getInnerjoin = from Clientes in _db.Clientes
        //                       where Clientes.ClienteId==Clientes.ClienteId
        //                       select Clientes;
        //    ViewBag.Clientes = getInnerjoin.Count();
        //    return View();
        //}
        public IActionResult Dasboard()
        {
            var getInnerjoin = from Clientes in _db.Clientes
                               where Clientes.ClienteId == Clientes.ClienteId
                               select Clientes;
            ViewBag.Clientes = getInnerjoin.Count();
           
            return View();
        }
    }
}
