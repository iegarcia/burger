using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult LogIn(LoginModel modelo)
        {
            var user = RNUser.BuscarUsuario(modelo.Usuario, modelo.Password);
            SessionHelper.UsuarioLogueado = user;
            if (user != null && user.Role == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return Redirect("/Home");
            }
        }
    }
}
