using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidoStatusController : Controller
    {
        // GET: PedidoStatus
        public ActionResult SeguirEnvio(int id)
        {
            Pedido p = RNPedidos.BuscarPedido(id);
            PedidoModel res = new PedidoModel
            {
                PedidoId = p.Id,
                EstadoDelPedido = p.EstadoPedido
            };
            return View("PedidoStatus", res);
        }

    }
}