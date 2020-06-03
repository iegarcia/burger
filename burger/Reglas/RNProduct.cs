using burger.Acceso_Datos;
using burger.Entidades;
using System;

namespace burger.Reglas
{
    public class RNProduct
    {
        public static Producto BuscarProducto(int idProducto)
        {
            return ADProducto.Buscar(idProducto);
        }
        public static void RestablecerBD()
        {
            ADProducto.Restablecer();
        }
    }
}