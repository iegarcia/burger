using burger.Entidades;
using burger.Models;
using burger.Reglas;
using Microsoft.Ajax.Utilities;
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

        public static List<ProductoPedido> ProductosCarrito
        {
            get
            {
                if (HttpContext.Current.Session["ProductosPedidos"] == null)
                    HttpContext.Current.Session["ProductosPedidos"] = new List<ProductoPedido>();
                return (List<ProductoPedido>)HttpContext.Current.Session["ProductosPedidos"];
            }
        }

        public static bool ComprobarPersmisos(User user)
        {
            return user.Role == 1;
        }

        public static void Reset()
        {
            ProductosCarrito.Clear();
        }

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
            Reset();
        }
    }
}