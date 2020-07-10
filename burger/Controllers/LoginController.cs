using burger.Entidades;
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

            if (user != null && SessionHelper.ComprobarPersmisos(user) )
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return Redirect("/Home");
            }
        }

        public ActionResult CerrarSesion()
        {
            SessionHelper.CerrarSesion();
            return Redirect("/Home/Index");
        }
    }
}
