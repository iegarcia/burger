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
            ActionResult validar;
            if (usuario == null)
            {
                validar = Redirect("/Login/Index");
            }
            else if (SessionHelper.ComprobarPersmisos(usuario))
            {
                validar = Redirect("/Home/Index");
            }
            else
            {
                UserModel modelo = new UserModel
                {
                    ListaUsuarios = users,
                    UsuarioLogueado = usuario.Usuario

                };
                validar = View("Usuarios", modelo);
            }
            return validar;
        }
    }
}
