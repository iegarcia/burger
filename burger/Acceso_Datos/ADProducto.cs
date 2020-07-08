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