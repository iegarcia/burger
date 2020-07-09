using burger.BurgerDatos;
using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static bool Delete(int id)
        {
            User user;
            int result = 0;
            using (Context context = new Context())
            {
                user = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                context.Usuarios.Remove(user);
                result = context.SaveChanges();
            }
            return result > 0;
        }

        public static User Edit(User user)
        {
            User usuario;
            using (Context context = new Context())
            {
                usuario = context.Usuarios.Where(u => u.Id == user.Id).FirstOrDefault();
                usuario.Nombre = user.Nombre;
                usuario.Usuario = user.Usuario;
                usuario.Email = user.Email;
                usuario.Password = user.Password;
                usuario.Role = user.Role;
                context.SaveChanges();
            }
            return usuario;
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