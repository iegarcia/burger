using burger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Resumen
        public ActionResult Index()
        {
            return View("Checkout");
        }

        public ActionResult AgregarDatos(DeliveryModel model)
        {
            return View("Chechout");
        }
    }
}