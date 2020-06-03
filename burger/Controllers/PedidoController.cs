using burger.Acceso_Datos;
using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Collections.Generic;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidoController : Controller
    {
        public List<Producto> ProductosCarrito
        {
            get
            {
                return (List<Producto>)Session["Productos"];
            }
        }

        // GET: Resumen
        public ActionResult Index()
        {
            return View("Delivery");
        }

        public ActionResult CargarDatos(DeliveryModel usuario)
        {
            var pedido = new PedidoModel
            {
                ProductosPedidos = this.ProductosCarrito,
                DatosConsumidor = usuario
            };
            return View("Delivery", pedido);
        }
        public ActionResult Reset()
        {
            ProductosCarrito.Clear();
            RNProduct.RestablecerBD();
            return Redirect("/Home/Index");
        }
    }
}


        