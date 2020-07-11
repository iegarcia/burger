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

        public static bool Agregar(Producto prod)
        {
            return ADProducto.Agregar(prod);
        }

        public static bool BuscarProductoPorNombre(string nombre)
        {
            return ADProducto.BuscarProducto(nombre);
        }

        // Devuelve la cant de productos vendidos ordenados por id
        public static int[] ProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            return ADProducto.BuscarProductosMasVendidos(fechaInicio,fechaFin);
        }
    }
}