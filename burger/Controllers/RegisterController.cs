using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        public ActionResult Register(User modelo)
        {
            RNUser.Agregar(modelo);
            return View("Register", modelo);
        }
    }
}