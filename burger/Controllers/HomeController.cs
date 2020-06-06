using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using burger.BurguerDatos;
using burger.Entidades;

namespace burger.Controllers
{
    public class HomeController : Controller
    {

        //public List<Producto> Productos
        //{
        //    get
        //    {
        //        if (Session["Productos"] == null)
        //            Session["Productos"] = new List<Producto>();
        //        return (List<Producto>)Session["Productos"];
        //    }
        //}

        //public List<Producto> ProductosCarrito
        //{
        //    get
        //    {
        //        if (Session["ProductosCarrito"] == null)
        //            Session["ProductosCarrito"] = new List<Producto>();
        //        return (List<Producto>)Session["ProductosCarrito"];
        //    }
        //}

        

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public void AddProduct(Producto producto) {
            Context contexto = new Context();
            contexto.Productos.Add(producto);
            contexto.SaveChanges();

        }


    }
}
