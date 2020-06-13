using burger.Acceso_Datos;
using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidoController : Controller
    {
        public List<ProductoPedido> ProductosCarrito
        {
            get
            {
                return (List<ProductoPedido>)Session["ProductosPedidos"];
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
            return Redirect("/Home/Index");
        }

        private Boolean ConfirmarPedido(PedidoModel pedidoModel) {
            Pedido pedidoDB = new Pedido
            {
               Calle = pedidoModel.DatosConsumidor.Calle,
               Numero = pedidoModel.DatosConsumidor.Numero,
               Piso = pedidoModel.DatosConsumidor.Piso,
               Depto = pedidoModel.DatosConsumidor.Depto,
               Telefono = pedidoModel.DatosConsumidor.Telefono,
               Total = pedidoModel.Sumar(ProductosCarrito),
               FechaDePedido = DateTime.Now
            };

            int dbImpactPedido = 0;
            int dbImpactProductos = 0;

            using (Context context = new Context())
            {
                context.Pedidos.Add(pedidoDB);
                dbImpactPedido = context.SaveChanges();

                List<ProductosPorPedido> productosPorPedido = ProductosCarrito.Select(producto =>
                {
                    return new ProductosPorPedido
                    {
                        ProductoId = producto.Producto.Id,
                        PedidoId = pedidoDB.Id,
                        Cantidad = producto.Cantidad
                    };
                }).ToList();

                context.ProductosPorPedido.AddRange(productosPorPedido);
                dbImpactProductos = context.SaveChanges();
            }

            

            return dbImpactPedido > 0 && dbImpactProductos == ProductosCarrito.Count();
        }

    }
}


