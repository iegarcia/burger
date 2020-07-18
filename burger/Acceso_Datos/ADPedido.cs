using burger.BurgerDatos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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

        public static int Contar(DateTime fechaInicio, DateTime fechaFin)
        {
            int cant;
            using (Context context = new Context())
            {
                cant = context.Pedidos.Where(p => p.FechaDePedido >= fechaInicio && p.FechaDePedido <= fechaFin).Count();
            }
            return cant;
        }

        public static Pedido Send(Pedido ped)
        {
            Pedido pedido;
            //EstadoPedido.Estado nuevoEstado;
            using (Context context = new Context())
            {
                pedido = context.Pedidos.Where(p => p.Id == ped.Id).FirstOrDefault();
                pedido.EstadoPedido = EstadoPedido.Estado.EN_CAMINO;
                context.SaveChanges();
            }
            return pedido;
        }

        public static Pedido Success(Pedido ped)
        {
            Pedido pedido;
            //EstadoPedido.Estado entregado;
            using (Context context = new Context())
            {
                pedido = context.Pedidos.Where(p => p.Id == ped.Id).FirstOrDefault();
                pedido.EstadoPedido = EstadoPedido.Estado.ENTREGADO;
                context.SaveChanges();
            }
            return pedido;
        }
    }
}