using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class UserModel
    {
        public List<User> ListaUsuarios { get; set; }
        public string UsuarioLogueado { get; set; }
    }
}