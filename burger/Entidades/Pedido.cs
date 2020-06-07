using burger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public User usuario { get; set; }
        public List<Producto> Precio { get; set; }
        public DeliveryModel datosDelPedido { get; set; }
        public double Total { get; set; }
    }
}