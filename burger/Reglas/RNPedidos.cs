using burger.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace burger.Reglas
{
    public class RNPedidos : Controller
    {
        // GET: RNPedidos
        public static List<Pedido> ListarPedidos() //Metodo exclusivo para el admin...
        {
            return ADPedido.Listar();
        }
    }
}