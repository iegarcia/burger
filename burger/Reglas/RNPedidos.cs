﻿using burger.Acceso_Datos;
using burger.Entidades;
using System;
using System.Collections.Generic;

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

        public static Pedido Confirmar(int id)
        {
            Pedido ped = BuscarPedido(id);
            return ADPedido.Success(ped);
        }


        public static int ContarPedidos()
        {
            return ADPedido.Contar();
        }

        public static int ContarPedidosEnFechasEspecificas(DateTime fechaInicio, DateTime fechaFin)
        {
            return ADPedido.Contar(fechaInicio, fechaFin);
        }

        public static Pedido Enviar(int id)
        {
            Pedido ped = BuscarPedido(id);
            return ADPedido.Send(ped);
        }
    }
}