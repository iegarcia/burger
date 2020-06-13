using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Entidades
{
    public class ProductoPedido
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public double Total { get; set; }
    }
}