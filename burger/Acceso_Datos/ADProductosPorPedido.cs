using burger.BurgerDatos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Acceso_Datos
{
    public class ADProductosPorPedido
    {
        public static List<ProductosPorPedido> ListarProductos(int idPedido)
        {
            List<ProductosPorPedido> pxp = new List<ProductosPorPedido>();
            using (Context context = new Context())
            {
                List<ProductosPorPedido> productosPorPedidos = context.ProductosPorPedido.ToList();

                pxp = productosPorPedidos.Where(
                    prod => prod.PedidoId == idPedido
                    ).ToList();
            }
            return pxp;
        }
    }
}