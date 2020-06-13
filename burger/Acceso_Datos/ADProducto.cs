using burger.BurgerDatos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Acceso_Datos
{
    public class ADProducto
    {
        private static Context Context = new Context();
        public static Producto Buscar(int idProducto)
        {
            List<Producto> productos = Context.Productos.ToList();
            
            return productos.Where(
                prod => prod.Id == idProducto
                ).FirstOrDefault();

        }
    }
}