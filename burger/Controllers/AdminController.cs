using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var usuario = SessionHelper.UsuarioLogueado;
            var users = RNUser.ListarUsuarios();
            AdminModel modelo = new AdminModel();
            if (usuario.Role == 1)
            {
                modelo.UsuarioLogueado = usuario.Usuario;
            }
            return View("Admin", modelo);
        }
    }
}