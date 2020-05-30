using burger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Models
{
    public class UserModel
    {
        public List<User> ListaUsuarios{ get; set; }
        public string UsuarioLogueado { get; set; }
    }
}