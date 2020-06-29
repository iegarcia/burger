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
        public static int Contar()
        {
            int cant;
            using (Context context = new Context())
            {
                cant = context.Pedidos.Count();
            }
            return cant;
        }

        public static Pedido Success(Pedido ped)
        {
            Pedido pedido;
            EstadoPedido.Estado entregado;
            using (Context context = new Context())
            {
                pedido = context.Pedidos.Where(p => p.Id == ped.Id).FirstOrDefault();
                entregado = pedido.EstadoPedido = EstadoPedido.Estado.ENTREGADO;
                context.SaveChanges();
            }
            return pedido;
        }
    }
}