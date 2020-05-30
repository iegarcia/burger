using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Acceso_Datos
{
    public static class BaseDeDatos
    {
        public static List<User> Usuarios
        {
            get;
            set;
        } = new List<User>();        
        
        public static List<Producto> Productos
        {
            get;
            set;
        } = new List<Producto>();
    }
}