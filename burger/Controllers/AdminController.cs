﻿using burger.Models;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var usuario = SessionHelper.UsuarioLogueado;
            AdminModel modelo = new AdminModel();
            if (usuario == null)
            {
                Redirect("Login/Index");
            }
            else if (usuario.Role == 1)
            {
                modelo.UsuarioLogueado = usuario.Usuario;
            }
            return View("Admin", modelo);
        }
    }
}