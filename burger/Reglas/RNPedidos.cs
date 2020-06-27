using burger.Acceso_Datos;
using burger.Entidades;
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
    }
}