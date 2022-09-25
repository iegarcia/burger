using burger.Acceso_Datos;
using burger.Entidades;
using System.Collections.Generic;

namespace burger.Reglas
{
    public class RNProductosPorPedidos
    {
        public static List<ProductosPorPedido> ProdPorPed(int idPed)
        {
            return ADProductosPorPedido.ListarProductos(idPed);
        }
    }
}