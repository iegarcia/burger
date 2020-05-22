
using burger.Models;
using System.CodeDom.Compiler;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace burger.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(LoginModel modelo)
        {
            if (modelo.NombreUsuario.Equals("pepe") && modelo.Password.Equals("pepe"))
            {
                return Redirect("/Checkout");
            }
            else
            {
                return View();
            }
        }
    }
}