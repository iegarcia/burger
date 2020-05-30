using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Acceso_Datos
{
    public class ADProducto
    {
        public static Producto Buscar(int idProducto)
        {
            return BaseDeDatos.Productos.Where(
                prod => prod.Id == idProducto
                ).FirstOrDefault();
        }
    }
}