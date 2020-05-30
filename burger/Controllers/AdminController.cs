using burger.Models;
using burger.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var users = RNUser.ListarUsuarios();
            UserModel modelo = new UserModel
            {
                ListaUsuarios = users,
                UsuarioLogueado = "Hola que tal"
            };
            return View("ListadoUsuarios", modelo);
        }
    }
}