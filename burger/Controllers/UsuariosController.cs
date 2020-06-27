using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            var usuario = SessionHelper.UsuarioLogueado;
            var users = RNUser.ListarUsuarios();
            ActionResult validar = null;
            if (usuario == null)
            {
                validar = Redirect("/Login/Index");
            }
            else
            {
                UserModel modelo = new UserModel
                {
                    ListaUsuarios = users,
                };
                if (usuario.Role == 1)
                {
                    modelo.UsuarioLogueado = usuario.Usuario;
                    validar = View("Usuarios", modelo);
                }
            }
            return validar;
        }
    }
}
