using burger.Entidades;
using burger.Models;
using burger.Reglas;
using Microsoft.Ajax.Utilities;
using System;
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
            Boolean existe = true;
            var buscar = BuscarProd(producto);
            if (buscar == null)
            {
                existe = false;
            }
            return existe;
        }

        private Producto BuscarProd(Producto producto)
        {
            int i = 0;
            int id;
            Producto encontrado = null;
            while (i < ProductosCarrito.Count && encontrado == null)
            {
                encontrado = ProductosCarrito[i];
                id = encontrado.Id;
                if (!(id == producto.Id))
                {
                    i++;
                    encontrado = null;
                }
            }
            return encontrado;
        }
    }
}