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
            return this.CarritoActualizado();
        }
        public List<ProductoPedido> ProductosCarrito
        {
            get
            {
                if (Session["ProductosPedidos"] == null)
                    Session["ProductosPedidos"] = new List<ProductoPedido>();
                return (List<ProductoPedido>)Session["ProductosPedidos"];
            }
        }
        public ActionResult Agregar(int id)
        {
            ProductoPedido producto = this.BuscarProducto(id);
            if (producto != null)
            {
                producto.Cantidad++;
                producto.Total = producto.Cantidad * producto.Producto.Precio;
            }
            else
            {
                Producto productoObject = RNProduct.BuscarProducto(id);
                ProductoPedido nuevoProducto = new ProductoPedido
                {
                    Producto = productoObject,
                    Cantidad = 1,
                    Total = productoObject.Precio
                };
                ProductosCarrito.Add(nuevoProducto);
            }
            return this.CarritoActualizado();
        }

        private double Sumar(List<ProductoPedido> productos)
        {
            double acumPrecio = 0;
            foreach (var prod in productos)
            {
                var precio = prod.Producto.Precio * prod.Cantidad;
                acumPrecio += precio;
            }
            return acumPrecio;
        }

        private ProductoPedido BuscarProducto(int id)
        {
            return ProductosCarrito.Find(prod => prod.Producto.Id == id);
        }

        public ActionResult Eliminar(int id)
        {
            ProductoPedido prod = BuscarProducto(id);

            if (prod != null)
            {
                if (prod.Cantidad > 1)
                {
                    prod.Cantidad--;
                    prod.Total = prod.Producto.Precio * prod.Cantidad;
                }
                else
                {
                    this.ProductosCarrito.Remove(prod);
                }
            }

            return this.CarritoActualizado();
        }

        private ActionResult CarritoActualizado()
        {
            var carrito = new CarritoModel
            {
                ListaProductos = this.ProductosCarrito,
                Total = Sumar(this.ProductosCarrito)
            };

            return View("Carrito", carrito);
        }
    }
}