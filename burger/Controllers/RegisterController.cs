using burger.Entidades;
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
            // Los usuarios que se  den de alta por este metodo van a ser de tipo cliente, por eso seteamos el role en 0
            modelo.Role = 0;
            var userAdded = RNUser.Agregar(modelo);
            ActionResult response = View("Register");

            if (userAdded)
            {
                SessionHelper.UsuarioLogueado = modelo;
                response = Redirect("/Home");
            }

            return response;
        }
    }
}