using burger.Entidades;
using System.Collections.Generic;
using burger.BurgerDatos;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Data.Entity.Migrations;

namespace burger.Acceso_Datos
{
    public class ADPedido : Controller
    {
        public static List<Pedido> Listar()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (Context context = new Context())
            {
                pedidos = context.Pedidos.ToList();
            }
            return pedidos;
        }

        public static Pedido BuscarPorID(int pedidoId)
        {
            Pedido ped;
            using (Context context = new Context())
            {
                ped = context.Pedidos.Where(p => p.Id == pedidoId).FirstOrDefault();
            }

            return ped;
        }

        internal static EstadoPedido.Estado Success(Pedido ped)
        {
            Pedido pedido;
            using (Context context = new Context())
            {
                pedido = context.Entry(ped).Property(p => p.EstadoPedido).CurrentValue = EstadoPedido.Estado.ENTREGADO;
            }
            return pedido;
        }
    }
}