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

        public static List<User> Listar()
        {
            List<User> users = new List<User>();

            using (Context context = new Context())
            {
                users = context.Usuarios.ToList();
            }

            return users;
        }

        public static Boolean Agregar(User user)
        {
            int dbImpact = 0;
            using (Context context = new Context())
            {
                context.Usuarios.Add(user);
                dbImpact = context.SaveChanges();
            }

            return dbImpact > 0;
        }

        public static User Buscar(string usuario, string password)
        {
            User user;
            using (Context context = new Context())
            {
                user = context.Usuarios.Where(u => u.Usuario == usuario && u.Password == password).FirstOrDefault();
            }

            return user;
        } 
        public static User BuscarPorID(int usuarioId)
        {
            User user;
            using (Context context = new Context())
            {
                user = context.Usuarios.Where(u => u.Id == usuarioId).FirstOrDefault();
            }

            return user;
        }

        public static bool ExisteUsuario(string usuario)
        {

            Boolean existe = false;

            using (Context context = new Context())
            {
                existe = context.Usuarios.Any(
                    user => user.Usuario == usuario);

            }

            return existe;
        }
    }
}