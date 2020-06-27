using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidosController : Controller
    {
        public ActionResult Index()
        {
            // Aca hay que meter la logica para levantar los pedidos y mandarlos
            return View ("Pedidos");
        }
    }
}
