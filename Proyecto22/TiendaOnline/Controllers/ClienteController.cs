using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace TiendaOnline.Controllers
{
    
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
            ViewBag.IdCliente=TempData["ID"];
            ViewBag.correoCliente = TempData["correo"];
            //int id = ViewBag.IdCliente;
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
                                   precio = Articulos.Precio,
                                   img=Articulos.Imagen

                               };
          

            ViewBag.join = getInnerJoin;

            return View();
        }

        public IActionResult Confirmacion(int id, int idp, Carritos cars)
        {
           

                cars.ArticuloID = idp;
                cars.UsuarioID = id;
                cars.Cantidad = 1;

            _car.AddCarrito(cars);

            TempData["confirmacion"] = "Producto Agregado al carrito!!!";
            TempData["ID"] = id;

            return RedirectToAction("Index");
        }

        public IActionResult NewCars(Carritos cars)
        {
            int id = cars.UsuarioID;
            _car.AddCarrito(cars);


            TempData["ID"] = id;

            return RedirectToAction("Index");
        }

        public IActionResult VerProducto(int id, int idp)
        {
            //ViewBag.confirmacion = TempData["confirmacion"];
            var getInnerJoin = from Categorias in _db.Categorias
                               from Articulos in _db.Articulos
                               where Articulos.ArticuloId == idp &&
                               Categorias.CategoriaId == Articulos.CategoriaID
                               select new
                               {
                                   catgoria = Categorias.Tipo,
                                   id = Articulos.ArticuloId,
                                   cantida = Articulos.Cantidad,
                                   nombre = Articulos.Nombre,
                                   descripcion = Articulos.Descripcion,
                                   precio= Articulos.Precio,
                                   img=Articulos.Imagen

                               };
            ViewBag.id = id;
            TempData["ID"] = id;
            ViewBag.join = getInnerJoin;
            return View();
        }

        public IActionResult Carrito(string id)
        {
            if (id != null) {
                int ID = int.Parse(id);
                var carrito = from Carritos in _db.Carritos
                              from Usuarios in _db.Usuarios
                              where Carritos.Usuario.UsuarioId == ID
                              &&
                              Carritos.UsuarioID == Usuarios.UsuarioId
                              select new
                              {

                                  cantida = Carritos.Cantidad,
                                  nombre = Carritos.Articulo.Nombre,
                                  precio = Carritos.Articulo.Precio,
                                  fecha = Carritos.Fecha,
                                  carriroid=Carritos.CarritoId,
                                  img=Carritos.Articulo.Imagen
                              };
                ViewBag.cars = carrito;
                
                TempData["ID"] = id;
            }
            
            
            return View();
        }

        public IActionResult DeleteCarrito(int id)
        {
            
            Carritos cars = new Carritos();
            cars.CarritoId = id;

            var carrito = from Carritos in _db.Carritos
                          from Usuarios in _db.Usuarios
                          where Carritos.CarritoId == id
                         &&
                         Carritos.UsuarioID == Usuarios.UsuarioId
                          select new
                          {

                              iduser = Carritos.UsuarioID
                         };

            foreach(var c in carrito)
            {
                ViewBag.id = c.iduser;
            }
            _car.DeleteCarrito(cars);
            int IdUser = ViewBag.id;

            TempData["ID"]=IdUser;  
            return RedirectToAction("Index");
        }
    }
}
