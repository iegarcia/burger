using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Collections.Generic;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidosController : Controller
    {
        public ActionResult Index()
        {
            var usuario = SessionHelper.UsuarioLogueado;
            ActionResult validar = Redirect("/Home/Index");
            if (usuario == null)
            {
                validar = Redirect("/Login/Index");
            }
            else if (SessionHelper.ComprobarPersmisos(usuario))
            { 
      
                var listaPedidos = RNPedidos.ListarPedidos();
                List<PedidoCompleto> pedidos = ArmarPedidoCompleto(listaPedidos);
                PedidoAdminModel pam = new PedidoAdminModel
                {
                    Pedidos = pedidos
                };
                validar = View("Pedidos", pam);
                
            }
            return validar;

        }

        public ActionResult EnviarPedido(int id)
        {
            var p = RNPedidos.Enviar(id);
            return RedirectToAction("Index", p);
        }


        public ActionResult ConfirmarEntrega(int id)
        {
            var res = RNPedidos.Confirmar(id);
            return RedirectToAction("Index", res);
        }

        public List<PedidoCompleto> ArmarPedidoCompleto(List<Pedido> listaPedidos)
        {
            List<PedidoCompleto> pedidosCompletos = new List<PedidoCompleto>();
            foreach (var ped in listaPedidos)
            {
                pedidosCompletos.Add(new PedidoCompleto
                {
                    Pedido = ped,
                    Usuario = RNUser.BuscarUsuarioPorId(ped.UsuarioId),
                    ProductosPedidos = BuscarProdsPedidos(ped.Id)
                });
            }
            return pedidosCompletos;
        }

        private List<ProductoPedido> BuscarProdsPedidos(int id)
        {
            List<ProductosPorPedido> productosPors = RNProductosPorPedidos.ProdPorPed(id);
            List<ProductoPedido> response = new List<ProductoPedido>();
            foreach (var item in productosPors)
            {
                Producto p = RNProduct.BuscarProducto(item.ProductoId);
                response.Add(new ProductoPedido
                {
                    Producto = p,
                    Cantidad = item.Cantidad,
                    Total = p.Precio * item.Cantidad
                });
            }
            return response;
        }
    }
}
