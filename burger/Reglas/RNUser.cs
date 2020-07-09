using burger.Acceso_Datos;
using burger.Entidades;
using System;
using System.Collections.Generic;

namespace burger.Reglas
{
    public static class RNUser
    {
        public static List<User> ListarUsuarios() //Metodo exclusivo para el admin...
        {
            return ADUser.Listar();
        }

        public static User BuscarUsuario(string usuario, string password)
        {
            return ADUser.Buscar(usuario, password);
        }
        public static User BuscarUsuarioPorId(int userId)
        {
            return ADUser.BuscarPorID(userId);
        }

        public static Boolean Agregar(User user)
        {
            if (ADUser.ExisteUsuario(user.Usuario))
            {
                throw new Exception("Usuario Existente");
            }

            return ADUser.Agregar(user);
        }

        public static User Editar(User user)
        {
            return ADUser.Edit(user);
        }

        public static bool Eliminar(int id)
        {
            return ADUser.Delete(id);
        }
    }
}