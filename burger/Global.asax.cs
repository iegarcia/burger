using burger.BurgerDatos;
using burger.Entidades;
using System;
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
                Usuario = "admin",
                Email = "admin@test.com",
                Password = "1234",
                Role = 1
            };

            User user2 = new User
            {
                Usuario = "ignacio",
                Email = "ignacio@test.com",
                Password = "1234",
                Role = 0
            };

            User user3 = new User
            {
                Usuario = "Fulanito",
                Email = "fulanito@test.com",
                Password = "1234",
                Role = 0
            };

            User user4 = new User
            {
                Usuario = "usuario",
                Email = "usuario@test.com",
                Password = "1234",
                Role = 0
            };

            Producto p1 = new Producto
            {
                Id = 1,
                Nombre = "Wea",
                Precio = 100,
                Imagen = "burger01.jpg",
                Descripcion = "Siente todo el sabor de la cocina mexicana en tu paladar! Viva Mexico Cabrones!!!"
            };


            Producto p2 = new Producto
            {
                Id = 2,
                Nombre = "The Bob Marley",
                Precio = 100,
                Imagen = "burger02.jpg",
                Descripcion = "Aumenta tu vibra con esta reggae burger. Una vez que la pruebes, you are gonna love it!"
            };


            Producto p3 = new Producto
            {
                Id = 3,
                Nombre = "Classic Burger",
                Precio = 100,
                Imagen = "burger03.jpg",
                Descripcion = "Si estas hecho a la antigua y prefieris los clasicos. Tenemos una hamburguesa que va con vos."
            };

            Producto p4 = new Producto
            {
                Id = 4,
                Nombre = "Veggie",
                Precio = 100,
                Imagen = "burger04.jpg",
                Descripcion = "El perfecto mix de la cocina vegana combinado con los mejores elementos de la naturaleza!"
            };


            Pedido pedido1 = new Pedido
            {
                UsuarioId = 1,
                Calle = "Falsa",
                Numero = "123",
                Telefono = "153223213",
                Total = 280,
                FechaDePedido = DateTime.Today,
                EstadoPedido = EstadoPedido.Estado.ENTREGADO
            };

            Pedido pedido2 = new Pedido
            {
                UsuarioId = 1,
                Calle = "Falsa",
                Numero = "123",
                Telefono = "153223213",
                Total = 200,
                FechaDePedido = DateTime.Today.AddDays(-20),
                EstadoPedido = EstadoPedido.Estado.ENTREGADO
            };

            ProductosPorPedido ppp1 = new ProductosPorPedido
            { 
                PedidoId = 1,
                ProductoId = 1,
                Cantidad = 3
            };

            ProductosPorPedido ppp2 = new ProductosPorPedido
            {
                PedidoId = 1,
                ProductoId = 2,
                Cantidad = 2
            };

            ProductosPorPedido ppp3 = new ProductosPorPedido
            {
                PedidoId = 1,
                ProductoId = 3,
                Cantidad = 2
            };

            ProductosPorPedido ppp4 = new ProductosPorPedido
            {
                PedidoId = 1,
                ProductoId = 4,
                Cantidad = 1
            };

            ProductosPorPedido ppp5 = new ProductosPorPedido
            {
                PedidoId = 2,
                ProductoId = 1,
                Cantidad = 4
            };

            ProductosPorPedido ppp6 = new ProductosPorPedido
            {
                PedidoId = 2,
                ProductoId = 4,
                Cantidad = 3
            };

            ProductosPorPedido ppp7 = new ProductosPorPedido
            {
                PedidoId = 2,
                ProductoId = 2,
                Cantidad = 1
            };

            ProductosPorPedido ppp8 = new ProductosPorPedido
            {
                PedidoId = 2,
                ProductoId = 3,
                Cantidad = 1
            };

            using (Context context = new Context())
            {

                if (context.Productos.Count() == 0)
                {
                    context.Productos.Add(p1);
                    context.Productos.Add(p2);
                    context.Productos.Add(p3);
                    context.Productos.Add(p4);
                    context.SaveChanges();
                }

                if (context.Usuarios.ToList().Count() == 0)
                {
                    context.Usuarios.Add(user1);
                    context.Usuarios.Add(user2);
                    context.Usuarios.Add(user3);
                    context.Usuarios.Add(user4);
                    context.SaveChanges();
                }

                if (context.Pedidos.ToList().Count() == 0) {
                    context.Pedidos.Add(pedido1);
                    context.Pedidos.Add(pedido2);
                    context.SaveChanges();
                }

                if (context.ProductosPorPedido.ToList().Count() == 0)
                {
                    context.ProductosPorPedido.Add(ppp1);
                    context.ProductosPorPedido.Add(ppp2);
                    context.ProductosPorPedido.Add(ppp3);
                    context.ProductosPorPedido.Add(ppp4);
                    context.ProductosPorPedido.Add(ppp5);
                    context.ProductosPorPedido.Add(ppp6);
                    context.ProductosPorPedido.Add(ppp7);
                    context.ProductosPorPedido.Add(ppp8);
                    context.SaveChanges();
                }

            }





        }
    }
}
