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
        public static List<User> Listar()
        {
            return BaseDeDatos.Usuarios;
        }

        public static User Agregar(User user)
        {
            BaseDeDatos.Usuarios.Add(user);
            return user;
        }

        public static User Buscar(string usuario, string password)
        {
            return BaseDeDatos.Usuarios.Where(
                user => user.Password == password && 
                user.Usuario == usuario
                ).FirstOrDefault();
        }
        
        public static bool CuantosHay(string usuario)
        {
            return BaseDeDatos.Usuarios.Any(
               user => user.Usuario == usuario);
        }
    }
}