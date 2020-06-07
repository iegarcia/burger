using burger.Entidades;
using burger.Models;
using burger.Reglas;
using System.Collections.Generic;
using System.Web.Mvc;


namespace burger.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View("Carrito");
        }
        public List<Producto> ProductosCarrito
        {
            get
            {
                if (Session["Productos"] == null)
                    Session["Productos"] = new List<Producto>();
                return (List<Producto>)Session["Productos"];
            }
        }
        public ActionResult Agregar(int id)
        {
            Producto prod = RNProduct.BuscarProducto(id);
            if (EnCarrito(prod))
            {
                prod.Cantidad++;
                prod.Total = prod.Precio * prod.Cantidad;
            }
            else
            {
                prod.Total = prod.Precio * prod.Cantidad;
                this.ProductosCarrito.Add(prod);
            }
            var carrito = new CarritoModel
            {
                ListaProductos = this.ProductosCarrito
            };
            carrito.Total = Sumar(carrito);
            return View("Carrito", carrito);
        }

        private double Sumar(CarritoModel carrito)
        {
            double acumPrecio = 0;
            foreach (var prod in carrito.ListaProductos)
            {
                var precio = prod.Total;
                acumPrecio += precio;
            }
            return acumPrecio;
        }

        private bool EnCarrito(Producto producto)
        {
            bool existe = true;
            if (producto == null || BuscarProd(producto.Id) == null)
            {
                existe = false;
            }
            return existe;
        }

        private Producto BuscarProd(int id)
        {
            int i = 0;
            Producto producto;
            Producto productoEncontrado = null;
            int encontrado = 0;
            while (i < ProductosCarrito.Count && encontrado == 0)
            {
                producto = ProductosCarrito[i];
                encontrado = producto.Id;
                if (encontrado == id)
                {
                    productoEncontrado = producto;
                }
                else
                {
                    i++;
                    encontrado = 0;
                }
            }
            return productoEncontrado;
        }

        public ActionResult Eliminar(int id)
        {
            Producto prod = BuscarProd(id);
            if (EnCarrito(prod) && prod.Cantidad > 1)
            {
                prod.Cantidad--;
                prod.Total = prod.Precio * prod.Cantidad;
            }
            else
            {
                this.ProductosCarrito.Remove(prod);
            }
            var carrito = new CarritoModel
            {
                ListaProductos = this.ProductosCarrito
            };
            carrito.Total = Sumar(carrito);
            return View("Carrito", carrito);
        }
    }
}