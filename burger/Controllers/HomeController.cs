using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using burger.BurgerDatos;
using burger.Entidades;

namespace burger.Controllers
{
    public class HomeController : Controller
    {
        private Context context = new Context();

        public List<Producto> Productos
        {
            get
            {
                return context.Productos.ToList();
            }
        }


        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public void AddProduct(int productoId) {
            //Context contexto = new Context();
           
            //contexto.Productos.Add(producto);
            //contexto.SaveChanges();

        }


    }
}
