using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace TiendaOnline.Controllers
{
    /// <summary>
    /// PRUEVAAAAAAAAAAAAAAAAAAAAAA
    /// </summary>
    public class ClienteController : Controller
    {

        private IArticulos _articulos;
        private ICarritos _car;
        private readonly ILogger<ClienteController> _logger;
        private ApplicationDBContext _db;

        public ClienteController(ILogger<ClienteController> logger, IArticulos articulos,ICarritos car, ApplicationDBContext db)
        {
            _articulos = articulos;
            _car = car;
            _logger=logger;
            _db = db; 
        }
        public IActionResult Index()
        {
            ViewBag.confirmacion = TempData["confirmacion"];
            var getInnerJoin = from Categorias in _db.Categorias
                               from Articulos in _db.Articulos
                               where Categorias.CategoriaId == Articulos.CategoriaID
                               select new
                               {
                                   catgoria = Categorias.Tipo,
                                   id=Articulos.ArticuloId,
                                   cantida = Articulos.Cantidad,
                                   nombre = Articulos.Nombre,
                                   descripcion = Articulos.Descripcion,
                                   precio = Articulos.Precio

                               };
            ViewBag.join = getInnerJoin;

            return View();
        }

        public IActionResult Confirmacion(int id)
        {

            //var getInnerjoin = from Articulos in _db.Articulos
            //                   where Articulos.ArticuloId == id
            //                   select new
            //                   {
            //                       idArticulo = Articulos.ArticuloId
            //                   };
            //ViewBag.join = getInnerjoin;
            TempData["confirmacion"] = "Producto Agregado al carrito!!!";

            return RedirectToAction("Index");
        }

        
        public IActionResult VerProducto(int id)
        {
            ViewBag.confirmacion = TempData["confirmacion"];
            var getInnerJoin = from Categorias in _db.Categorias
                               from Articulos in _db.Articulos
                               where Articulos.ArticuloId == id &&
                               Categorias.CategoriaId == Articulos.CategoriaID
                               select new
                               {
                                   catgoria = Categorias.Tipo,
                                   id = Articulos.ArticuloId,
                                   cantida = Articulos.Cantidad,
                                   nombre = Articulos.Nombre,
                                   descripcion = Articulos.Descripcion,
                                   precio= Articulos.Precio

                               };
            ViewBag.join = getInnerJoin;
            return View();
        }

        public IActionResult Carrito()
        {
            var Getdata = from Carritos in _db.Carritos
                          from Articulos in _db.Articulos
                              //
                          select new
                          {
                              carID = Carritos.CarritoId,
                              artId = Articulos.ArticuloId,

                              cantida = Articulos.Cantidad,
                              nombre = Articulos.Nombre,
                              descripcion = Articulos.Descripcion,
                              precio = Articulos.Precio
                          };
            ViewBag.joinn = Getdata;
            return View();
        }
    }
}
