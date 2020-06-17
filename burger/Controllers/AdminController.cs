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
            UserModel modelo = new UserModel
            {
                ListaUsuarios = users,
            };
            if (usuario.Role == 1)
            {
                modelo.UsuarioLogueado = usuario.Usuario;
            }
            return View("ListadoUsuarios", modelo);
        }
    }
}