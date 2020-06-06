using System;
using System.Collections.Generic;
using System.Data.Entity;
using burger.Entidades;

namespace burger.BurguerDatos
{
    public class Context : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}
