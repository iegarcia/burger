using System.Data.Entity;
using burger.Entidades;

namespace burger.BurgerDatos
{
    public class Context : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<User> Usuarios { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

    }
}
