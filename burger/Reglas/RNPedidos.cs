using burger.Acceso_Datos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace burger.Reglas
{
    public class RNPedidos
    {
        public static List<Pedido> ListarPedidos() //Metodo exclusivo para el admin...
        {
            return ADPedido.Listar();
        }
        
        public static Pedido BuscarPedido(int id) //Metodo exclusivo para el admin...
        {
            return ADPedido.BuscarPorID(id);
        }

        internal static EstadoPedido.Estado Confirmar(int id)
        {
            Pedido ped = BuscarPedido(id);
            return ADPedido.Success(ped);
        }
    }
}