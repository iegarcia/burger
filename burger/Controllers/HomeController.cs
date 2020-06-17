using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;

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

        //[HttpPost]
        //public void AddProduct(int productoId) {
        //    //Lo tiene que agregar a la sesion


        //}

    }
}
