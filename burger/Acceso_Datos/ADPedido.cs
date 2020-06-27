using burger.Entidades;
using System.Collections.Generic;
using burger.BurgerDatos;
using System.Web.Mvc;
using System.Linq;

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
    }
}