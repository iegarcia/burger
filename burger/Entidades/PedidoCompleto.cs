using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Entidades
{
    public class PedidoCompleto
    {
        public Pedido Pedido { get; set; }
        public User Usuario { get; set; }
        public List<ProductoPedido> ProductosPedidos { get; set; }
    }
}