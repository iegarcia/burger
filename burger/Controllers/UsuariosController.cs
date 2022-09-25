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
            AdminModel modelo = new AdminModel();
            var users = RNUser.ListarUsuarios();
            ActionResult validar = Redirect("/Home/Index");
            if (usuario == null)
            {
                validar = Redirect("/Login/Index");
            }
            else if (SessionHelper.ComprobarPersmisos(usuario))
            {

                UserModel usermodelo = new UserModel
                {
                    ListaUsuarios = users,
                    UsuarioLogueado = usuario.Usuario

                };
                validar = View("Usuarios", usermodelo);

            }
            return validar;

        }
    }
}
