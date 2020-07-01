using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Collections.Generic;
using System.Web.Mvc;

namespace burger.Controllers
{
    public class PedidoStatusController : Controller
    {
        // GET: PedidoStatus
        public ActionResult SeguirEnvio(int id)
        {
            Pedido p = RNPedidos.BuscarPedido(id);
            PedidoModel pEncontrado = new PedidoModel
            {
                PedidoId = p.Id,
                DatosConsumidor = new DeliveryModel
                {
                    Calle = p.Calle,
                    Numero = p.Numero,
                    Piso = p.Piso,
                    Depto = p.Depto,
                    Telefono = p.Telefono,
                },
                EstadoDelPedido = p.EstadoPedido
            };
            return View("PedidoStatus", pEncontrado);
        }

    }
}