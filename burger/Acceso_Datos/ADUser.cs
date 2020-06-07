using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Acceso_Datos
{
    public class ADUser
    {
        private static Context context = new Context();
        public static List<User> Listar()
        {
            return context.Usuarios.ToList();
        }

        public static User Agregar(User user)
        {
            context.Usuarios.Add(user);
            return user;
        }

        public static User Buscar(string usuario, string password)
        {
            return context.Usuarios.Where(
                user => user.Password == password && 
                user.Usuario == usuario
                ).FirstOrDefault();
        }
        
        public static bool CuantosHay(string usuario)
        {
            return context.Usuarios.Any(
               user => user.Usuario == usuario);
        }
    }
}