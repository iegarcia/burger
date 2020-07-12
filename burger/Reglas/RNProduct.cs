using burger.Acceso_Datos;
using burger.Entidades;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

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

        // Devuelve las estadisticas productos vendidos ordenados por id
        public static ProductoEstadistica[] ProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            int[] cantVendida = ADProducto.BuscarProductosMasVendidos(fechaInicio, fechaFin);
            return RNProduct.generarEstadisticas(cantVendida);

        }

        // Genera un vector de porcentaje a partir de un vector de cantidades
        private static ProductoEstadistica[] generarEstadisticas(int[] cantidadVendida) {
            int totalVendido = 0;
            cantidadVendida.ForEach(cant => totalVendido += cant);
            
            ProductoEstadistica[] estadisticas = new ProductoEstadistica[cantidadVendida.Length];

            int idx = 0;
            try {
                cantidadVendida.ForEach(cant => {
                    Double estadistica = (cant * 100) / totalVendido;
                    Producto producto = ADProducto.Buscar(idx + 1);
                    estadisticas[idx] = new ProductoEstadistica() { 
                        producto = producto,
                        estadistica = estadistica
                    };
                    idx++;
                });
            } catch (Exception e) { 
                // No se pudo ejecutar
            }
            

            return estadisticas;
        }
    }
}