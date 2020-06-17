using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


namespace burger.Controllers
{
    public class SessionHelper
    {
        public static User UsuarioLogueado
        {
            get
            {
                if (HttpContext.Current.Session["UsuarioLogueado"] == null)
                    return null;
                return (User)HttpContext.Current.Session["UsuarioLogueado"];
            }
            set
            {
                HttpContext.Current.Session["UsuarioLogueado"] = value;
            }
        }
    }
}