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
        public User Usuario { get; set; }
        public List<Producto> ProductosSeleccionados { get; set; }
        public DeliveryModel DatosDeEnvio { get; set; }
        public double Total { get; set; }
    }
}