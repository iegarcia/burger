using burger.Acceso_Datos;
using burger.BurgerDatos;
using burger.Entidades;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace burger
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            User user1 = new User
            {
                Usuario = "ignacio",
                Email = "ignacio@test.com",
                Password = "1234",
                Role = 1
            };

            Producto p1 = new Producto
            {
                Id = 1,
                Nombre = "Wea",
                Cantidad = 1,
                Precio = 100
            };


            Producto p2 = new Producto
            {
                Id = 2,
                Nombre = "The Bob Marley",
                Cantidad = 1,
                Precio = 100
            };


            Producto p3 = new Producto
            {
                Id = 3,
                Nombre = "Classic Burger",
                Cantidad = 1,
                Precio = 100
            };

            Producto p4 = new Producto
            {
                Id = 4,
                Nombre = "Veggie",
                Cantidad = 1,
                Precio = 100
            };

            using (Context context = new Context()) {
             
                if (context.Productos.Count() == 0) {
                    context.Productos.Add(p1);
                    context.Productos.Add(p2);
                    context.Productos.Add(p3);
                    context.Productos.Add(p4);
                    context.SaveChanges();
                }

                if (context.Usuarios.ToList().Count() == 0) {
                    context.Usuarios.Add(user1);
                    context.SaveChanges();
                }

            }



             

        }
    }
}
