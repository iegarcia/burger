using burger.Acceso_Datos;
using burger.Entidades;
using System;
using System.Collections.Generic;

namespace burger.Reglas
{
    public class RNProduct
    {
        public static List<Producto> ListarProductos() //Metodo exclusivo para el admin...
        {
            return ADProducto.Listar();
        }

        public static Producto BuscarProducto(int idProducto)
        {
            return ADProducto.Buscar(idProducto);
        }

        public static Producto Editar(Producto prod)
        {
            return ADProducto.Editar(prod);
        }

        public static bool Eliminar(int id)
        {
            return ADProducto.Eliminar(id);
        }
    }
}