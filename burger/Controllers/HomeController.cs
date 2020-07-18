using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            List<Producto> ListaDeProductos = new List<Producto>();
            using (Context context = new Context())
            {
                ListaDeProductos = context.Productos.ToList();
            };

            ProductosModel ProductosModel = new ProductosModel
            {
                Productos = ListaDeProductos
            };
            return View("Index", ProductosModel);
        }
    }
}
