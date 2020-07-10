using burger.Models;
using burger.Reglas;
using System.Web.Mvc;
using burger.Entidades;

namespace burger.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var user = SessionHelper.UsuarioLogueado;
            var prod = RNProduct.ListarProductos();
            ActionResult validar = Redirect("/Home/Index");
            if (user == null)
            {
                validar = Redirect("/Login/Index");
            }
            else if (SessionHelper.ComprobarPersmisos(user))
            { 
                ProductosModel modelo = new ProductosModel
                {
                    Productos = prod,
                };
                validar = View("Productos", modelo);
            }
            return validar;
        }

        public ActionResult Delete(int id)
        {
            RNProduct.Eliminar(id);
            return Redirect("/Productos/Index");
        }

        public ActionResult Edit(Producto prod)
        {
            ActionResult result;
            var usuario = SessionHelper.UsuarioLogueado;
            result = Redirect("/Home/Index");
            if (SessionHelper.ComprobarPersmisos(usuario))
            {
                RNProduct.Editar(prod);
                result = Redirect("/Productos/Index");
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
                Producto prod = RNProduct.BuscarProducto(id);
                res = View("~/Views/Admin/EditProd", prod);
            }
            return res;
        }

    }
}