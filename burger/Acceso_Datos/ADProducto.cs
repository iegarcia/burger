using burger.BurgerDatos;
using burger.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace burger.Acceso_Datos
{
    public class ADProducto
    {
        public static Producto Buscar(int idProducto)
        {
            Producto producto;
            using (Context context = new Context())
            {
                List<Producto> productos = context.Productos.ToList();

                producto = productos.Where(
                    prod => prod.Id == idProducto
                    ).FirstOrDefault();
            }
            return producto;
        }

        public static Producto Editar(Producto prod)
        {
            Producto producto;
            using (Context context = new Context())
            {
                producto = context.Productos.Where(p => p.Id == prod.Id).FirstOrDefault();
                producto.Nombre = prod.Nombre;
                producto.Precio = prod.Precio;
                producto.Descripcion = prod.Descripcion;
                producto.Imagen = prod.Imagen;
                context.SaveChanges();
            }
            return producto;
        }

        public static bool BuscarProducto(string nombre)
        {
            Producto prod;
            bool result = false;
            using (Context context = new Context())
            {
                prod = context.Productos.Where(
                    producto => producto.Nombre == nombre
                    ).FirstOrDefault();
            }
            if(prod != null)
            {
                result = true;
            }
            return result;
        }

        public static bool Eliminar(int id)
        {
            Producto prod;
            int result = 0;
            using (Context context = new Context())
            {
                prod = context.Productos.Where(p => p.Id == id).FirstOrDefault();
                context.Productos.Remove(prod);
                result = context.SaveChanges();
            }
            return result > 0;
        }

        public static List<Producto> Listar()
        {
            List<Producto> products = new List<Producto>();

            using (Context context = new Context())
            {
                products = context.Productos.ToList();
            }

            return products;
        }

        public static bool Agregar(Producto prod)
        {
            int dbImpact = 0;
            using (Context context = new Context())
            {
                context.Productos.Add(prod);
                dbImpact = context.SaveChanges();
            }

            return dbImpact > 0;
        }

        public static int[] BuscarProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin) {

            int[] productos;

            using (Context context = new Context())
            {
                productos = new int[context.Productos.Count()];

                // Obtenemos los ids de pedidos solicitados (que esten entre las fechas que nos mandaron)
                List<int> idsDePedido = context.Pedidos
                    .Where(p => p.FechaDePedido >= fechaInicio && p.FechaDePedido <= fechaFin)
                    .Select(p => p.Id).ToList();

                // Obtenemos la lista de productos correspondientes a los pedidos
                List<ProductosPorPedido> productosFiltrados = context.ProductosPorPedido.Where(p => idsDePedido.Contains(p.PedidoId)).ToList();

                // Contamos la cantidad de productos
                foreach (ProductosPorPedido productoPorPedido in productosFiltrados)
                {
                    int posicionVector = productoPorPedido.ProductoId - 1;
                    productos[posicionVector] += productoPorPedido.Cantidad;
                }
            }

            return productos;
        } 
    }
}