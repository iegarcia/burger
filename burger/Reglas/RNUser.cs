using burger.Acceso_Datos;
using burger.BurgerDatos;
using burger.Entidades;
using burger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public static User Agregar(User user)
        {
            if (ADUser.ExisteUsuario(user.Usuario))
            {
                throw new Exception("Usuario Existente");
            }

            return ADUser.Agregar(user);
        }
    }
}