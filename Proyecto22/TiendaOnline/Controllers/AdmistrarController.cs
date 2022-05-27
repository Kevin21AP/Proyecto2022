using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;

namespace TiendaOnline.Controllers
{
    public class AdmistrarController : Controller
    {
        private ICompras _compra;
        private IVentas _venta;
        private ICarritos _car;
        private IArticulos _art;
         
        private readonly ILogger<AdmistrarController> _logger;
        private ApplicationDBContext _db;

        public AdmistrarController(ILogger<AdmistrarController> logger, ICompras compra, IVentas venta,
           ICarritos car,IArticulos articulo, ApplicationDBContext db)
        {
           _compra=compra;
            _venta=venta;
            _car=car;
            _art=articulo;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compra()
        {

            var compra = _db.Compras
               .Include(a => a.Articulo)
               .Include(p => p.Proveedor)
               .Include(e => e.Empleado)
               .ToList();

            Compras compras = new Compras();
            ViewBag.Articulo =  _db.Articulos.ToList();
            ViewBag.proveedor = _db.Proveedores.ToList();
            ViewBag.Empleado = _db.Empleados.ToList();
            ViewBag.compra = compra;
            return View(compras);
        }

        public IActionResult GuardarCompra(Compras comp)
        {
            int id = comp.ArticuloID;
            var subTotal = from articulo in _db.Articulos
                           where articulo.ArticuloId == id
                           select new
                           {
                               precio = articulo.Precio,
                               cout = articulo.Cantidad
                               
                           };

            foreach(var item in subTotal)
            {
                comp.Subtotal = item.precio * item.cout;
               
            }
            _compra.AddCompra(comp);

            return RedirectToAction("Compra");
        }

        public IActionResult EditCompra(int id)
        {
            Compras comp = new Compras();
            comp.CompraId = id;
            var list = _compra.loadCompra(comp);

            ViewBag.Articulo = _db.Articulos.ToList();
            ViewBag.proveedor = _db.Proveedores.ToList();
            ViewBag.Empleado = _db.Empleados.ToList();

            return View(list);
        }

        public IActionResult ActualizarCompra(Compras compra)
        {
            int id = compra.ArticuloID;
            var subTotal = from articulos in _db.Articulos
                           from comppras in _db.Compras
                           where articulos.ArticuloId == id
                           select new
                           {
                               precio = articulos.Precio,
                               cout = articulos.Cantidad
                           };
            foreach (var item in subTotal)
            {
                compra.Subtotal = item.precio * item.cout;
            }
            _compra.UpdateCompra(compra);
            return RedirectToAction("Compra");
        }

        public IActionResult DeleteCompra(int id)
        {
            Compras comp = new Compras();
            comp.CompraId = id;
            _compra.DeleteCompra(comp);
            return RedirectToAction("Compra");
        }

        //********************************* VENTAS ********************************************************8

        public IActionResult Venta()
        {

            var venta = _db.Ventas
               .Include(a => a.Articulo)
               .Include(c => c.Cliente)
               .Include(p => p.Pago)
               .Include(e => e.Empleado)
               .ToList();

            Ventas ventas = new Ventas();
            ViewBag.Articulo = _db.Articulos.ToList();
            ViewBag.cliente = _db.Clientes.ToList();
            ViewBag.pago = _db.Pagos.ToList();
            ViewBag.Empleado = _db.Empleados.ToList();

            ViewBag.venta = venta;
            return View(ventas);
        }

        public IActionResult GuardarVenta(Ventas vent)
        {
            int id = vent.ArticuloID;
            var subTotal = from articulo in _db.Articulos
                           where articulo.ArticuloId == id
                           select new
                           {
                               precio = articulo.Precio
                           };

            foreach (var item in subTotal)
            {
                vent.SubTotal = item.precio * vent.Cantidad;

            }
            _venta.AddVenta(vent);

            return RedirectToAction("Venta");
        }

        public IActionResult EditVenta(int id)
        {
            Ventas venta = new Ventas();
            venta.VentaId = id;
            var list = _venta.loadVenta(venta);

            ViewBag.Articulo = _db.Articulos.ToList();
            ViewBag.cliente = _db.Clientes.ToList();
            ViewBag.pago = _db.Pagos.ToList();
            ViewBag.Empleado = _db.Empleados.ToList();

            return View(list);
        }

        public IActionResult ActualizarVenta(Ventas Venta)
        {
            int id = Venta.ArticuloID;
            var subTotal = from articulo in _db.Articulos
                           where articulo.ArticuloId == id
                           select new
                           {
                               precio = articulo.Precio
                           };

            foreach (var item in subTotal)
            {
                Venta.SubTotal = item.precio * Venta.Cantidad;

            }
            _venta.UpdateVenta(Venta);
            return RedirectToAction("Venta");
        }

        public IActionResult DeleteVenta(int id)
        {
            Ventas vent = new Ventas();
            vent.VentaId = id;
            _venta.DeleteVenta(vent);
            return RedirectToAction("Venta");
        }


        //****************************** Carrito ************************************************

        public IActionResult Carrito()
        {

            var cars = _db.Carritos
               .Include(a => a.Articulo)
               .Include(u => u.Usuario)
               
               .ToList();

            Carritos carrito = new Carritos();
            ViewBag.articulo = _db.Articulos.ToList();
            ViewBag.usuario = _db.Usuarios.ToList();
            

            ViewBag.carrito = cars;
            return View(carrito);
        }

        public IActionResult GuardarCarrito(Carritos cars)
        {
           
            _car.UpdateCarrito(cars);
            return RedirectToAction("Carrito");
        }

        public IActionResult EditCarrito(int id)
        {
            Carritos carrito = new Carritos();
            carrito.CarritoId = id;
            var list = _car.loadCarrito(carrito);

            ViewBag.articulo = _db.Articulos.ToList();
            ViewBag.usuario = _db.Usuarios.ToList();

            return View(list);
        }

        public IActionResult ActualizarCarrito(Carritos cars)
        {
            _car.UpdateCarrito(cars);
            return RedirectToAction("Carrito");
        }

        public IActionResult DeleteCarrito(int id)
        {
            Carritos cars = new Carritos();
            cars.CarritoId = id;
            _car.DeleteCarrito(cars);
            return RedirectToAction("Carrito");
        }
    }
}
