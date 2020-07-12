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
    public class DeliveryController : Controller
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
            ActionResult action;
            if (ProductosCarrito == null)
            {
                action = Redirect("/Home/Index");
            }
            else
            {
                action = Redirect("/Carrito/Index");
            }
            return action;
        }

        public ActionResult CargarDatos(DeliveryModel datosDeEnvio)
        {
            ActionResult result;
            Boolean logged = EstaLogueado();
            if (!logged)
            {
                result = Redirect("/Login/Index");
            }
            else
            {
                //TODO revisar si esta bueno hardcodear el id
                PedidoModel pedido = new PedidoModel
                {
                    PedidoId = RNPedidos.ContarPedidos(),
                    ProductosPedidos = new List<ProductoPedido>(ProductosCarrito),
                    DatosConsumidor = datosDeEnvio,
                    EstadoDelPedido = EstadoPedido.Estado.EN_PREPARACIÓN,
                };
                pedido.PedidoId++;
                result = PrepararEnvio(pedido) ? View("Delivery", pedido) : View("Error");
            }
            return result;
        }

        public bool PrepararEnvio(PedidoModel pedido)
        {
            bool res = ConfirmarPedido(pedido);
            if (res)
            {
                SessionHelper.Reset();
            }
            return res;
        }

        public bool EstaLogueado()
        {
            return SessionHelper.UsuarioLogueado != null;
        }

        private Boolean ConfirmarPedido(PedidoModel pedidoModel)
        {
            Pedido pedidoDB = new Pedido
            {
                Id = pedidoModel.PedidoId,
                UsuarioId = SessionHelper.UsuarioLogueado.Id,
                Calle = pedidoModel.DatosConsumidor.Calle,
                Numero = pedidoModel.DatosConsumidor.Numero,
                Piso = pedidoModel.DatosConsumidor.Piso,
                Depto = pedidoModel.DatosConsumidor.Depto,
                Telefono = pedidoModel.DatosConsumidor.Telefono,
                Total = pedidoModel.Sumar(ProductosCarrito),
                FechaDePedido = DateTime.Now,
                EstadoPedido = EstadoPedido.Estado.CONFIRMADO
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


