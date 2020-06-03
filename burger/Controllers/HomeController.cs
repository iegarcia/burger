using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Usuario = SessionHelper.UsuarioLogueado.Usuario;
            return View();
        }
    }
}
