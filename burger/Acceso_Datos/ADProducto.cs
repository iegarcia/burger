using burger.BurgerDatos;
using burger.Entidades;
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

        public static bool Eliminar (int id)
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
    }
}