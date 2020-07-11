using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Web.Mvc;
using System;

namespace burger.Controllers
{
    public class AdminController : Controller
    {
        // Default fecha de hoy
        public DateTime fechaFin = DateTime.Today;
        // Default fecha de hace una semana
        public DateTime fechaInicio = DateTime.Today.AddDays(-(int) DateTime.Today.DayOfWeek);

        // GET: Admin
        public ActionResult Index()
        {
            var usuario = SessionHelper.UsuarioLogueado;
            ActionResult hayUsuario = Redirect("/Home/Index");
            if (usuario == null)
            {
                hayUsuario = Redirect("/Login/Index");
            }
            else if (SessionHelper.ComprobarPersmisos(usuario))
            {

                AdminModel modelo = new AdminModel() {
                    UsuarioLogueado = usuario.Usuario,
                    pedidosUltimaSemana = RNPedidos.ContarPedidos(),
                    productosMasVendidos = RNProduct.ProductosMasVendidos(fechaInicio, fechaFin)
            };

                hayUsuario = View("Admin", modelo);
            }

            return hayUsuario;
        }
        public ActionResult Edit(User user)
        {
            ActionResult result;
            var usuario = SessionHelper.UsuarioLogueado;
            result = Redirect("/Home/Index");
            if (SessionHelper.ComprobarPersmisos(usuario))
            {
                RNUser.Editar(user);
                result = Redirect("/Usuarios/Index");
            }
            return result;
        }

        public ActionResult Detalle(int id)
        {
            ActionResult res;
            var usuario = SessionHelper.UsuarioLogueado;
            res = Redirect("/Home/Index");
            if (SessionHelper.ComprobarPersmisos(usuario))
            {
                User user = RNUser.BuscarUsuarioPorId(id);
                res = View("Edit", user);
            }
            return res;
        }

        public ActionResult Delete(int id)
        {
            RNUser.Eliminar(id);
            return Redirect("/Usuarios/Index");
        }
    }
}