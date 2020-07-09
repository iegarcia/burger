using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var user = SessionHelper.UsuarioLogueado;
            var prod = RNProduct.ListarProductos();
            ActionResult validar;
            if (user == null)
            {
                validar = Redirect("/Login/Index");
            }
            else if (user.Role == 0)
            {
                validar = Redirect("/Home/Index");
            }
            else
            {
                ProductosModel modelo = new ProductosModel
                {
                    Productos = prod,
                };
                validar = View("Productos", modelo);
            }
            return validar;
        }
    }
}