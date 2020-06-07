using burger.Acceso_Datos;
using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System;
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

        public ActionResult CargarDatos(DeliveryModel datosDeEnvio)
        {
            var pedido = new PedidoModel
            {
                ProductosPedidos = ProductosCarrito,
                DatosConsumidor = datosDeEnvio
            };

            Boolean pedidoConfirmado = ConfirmarPedido(pedido);
            return pedidoConfirmado ? View("Delivery", pedido) : View("Error");
        }
        public ActionResult Reset()
        {
            ProductosCarrito.Clear();
            RNProduct.RestablecerBD();
            return Redirect("/Home/Index");
        }

        private Boolean ConfirmarPedido(PedidoModel pedidoModel) {
            Pedido pedidoDB = new Pedido
            {
                ProductosSeleccionados = ProductosCarrito,
                DatosDeEnvio = pedidoModel.DatosConsumidor,
                Total = pedidoModel.Sumar(ProductosCarrito)
            };

            int dbImpact = 0;

            using (Context context = new Context())
            {
                context.Pedidos.Add(pedidoDB);
                dbImpact = context.SaveChanges();
            }

            return dbImpact > 0;
        }

    }
}


