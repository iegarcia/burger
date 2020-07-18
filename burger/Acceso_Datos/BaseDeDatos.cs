using burger.Entidades;
using System.Collections.Generic;

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