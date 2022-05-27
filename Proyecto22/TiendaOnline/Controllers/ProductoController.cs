using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models;
using TiendaOnline.Services;


namespace TiendaOnline.Controllers
{
    public class ProductoController : Controller
    {
        private IArticulos _articulos;
        private ICategorias _categoria;
        private IProveedores _prov;
        private readonly ILogger<ClienteController> _logger;
        private ApplicationDBContext _db;

        public ProductoController(ILogger<ClienteController> logger, IArticulos articulos, ICategorias categoria,
            IProveedores prov, ApplicationDBContext db)
        {
            _articulos = articulos;
            _categoria = categoria;
            _prov = prov;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Guardar(Articulos art)
        {

            _articulos.AddArticulo(art);

            return RedirectToAction("Articulo");
        }
        public IActionResult Articulo()
        {
            var articulos = _db.Articulos
             
             .Include(c => c.Categoria)
             .ToList();

            Articulos articulo = new Articulos();
            ViewBag.articulo = articulos;
            ViewBag.Categoria =  _db.Categorias.ToList();
            return View(articulo);
        }

        public IActionResult Edit(int id)
        {
            Articulos art = new Articulos();
            art.ArticuloId = id;
            var listArticulo = _articulos.LoadArticulo(art);

            ViewBag.Categoria = _db.Categorias.ToList();
            return View(listArticulo);
        }

        public IActionResult Delete(int id)
        {
            Articulos art = new Articulos();
            art.ArticuloId = id;
            _articulos.DeleteArticulo(art);
            return RedirectToAction("Articulo");
        }
        public IActionResult Actualizar(Articulos art)
        {
            _articulos.UpdateAticulo(art);
            return RedirectToAction("Articulo");
        }

        //*********************** Proveedor ***************************************************

        public IActionResult Proveedor()
        {
            
            Proveedores proveedor = new Proveedores();
            ViewBag.proveedor = _prov.GetAll();
            return View(proveedor);
        }

        public IActionResult GuardarProveedor(Proveedores proveedor)
        {

            _prov.AddProveedor(proveedor);

            return RedirectToAction("Proveedor");
        }

        public IActionResult EditProveedor(int id)
        {
            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId = id;
            var list = _prov.loadProveedor(proveedor);
            return View(list);
        }

        public IActionResult ActualizarProveedor(Proveedores prov)
        {
            _prov.UpdateProveedor(prov);
            return RedirectToAction("Proveedor");
        }

        public IActionResult DeleteProveedor(int id)
        {
            Proveedores proveedor = new Proveedores();
            proveedor.ProveedorId = id;
            _prov.DeleteProveedor(proveedor);
            return RedirectToAction("Proveedor");
        }

        //*********************** Categorias ***************************************************

        public IActionResult Categoria()
        {
            var lista = _categoria.GetAll();
            ViewBag.Categoria = lista;
            return View();
        }

        public IActionResult GuardarCategoria(Categorias categoria)
        {

            _categoria.AddCategoria(categoria);

            return RedirectToAction("Categoria");
        }

        public IActionResult EditCategoria(int id)
        {
            Categorias categ = new Categorias();
            categ.CategoriaId = id;
            var list = _categoria.loadCategoria(categ);
            return View(list);
        }

        public IActionResult ActualizarCategoria(Categorias catg)
        {
            _categoria.UpdateCategoria(catg);
            return RedirectToAction("Categoria");
        }

        public IActionResult DeleteCategoria(int id)
        {
            Categorias categ = new Categorias();
            categ.CategoriaId = id;
            _categoria.DeleteCategoria(categ);
            return RedirectToAction("Categoria");
        }
    }
}
