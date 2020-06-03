using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class PedidoModel
    {
        public List<Producto> ProductosPedidos { get; set; }
        public DeliveryModel DatosConsumidor { get; set; }

    }
}