using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class CarritoModel
    {
        public List<ProductoPedido> ListaProductos { get; set; }
        public double Total { get; set; }

    }
}