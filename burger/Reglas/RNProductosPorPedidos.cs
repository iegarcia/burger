using burger.Acceso_Datos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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