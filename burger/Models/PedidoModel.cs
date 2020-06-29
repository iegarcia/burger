using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public List<ProductoPedido> ProductosPedidos { get; set; }
        public DeliveryModel DatosConsumidor { get; set; }
        public EstadoPedido.Estado EstadoDelPedido { get; set; }


        public double Sumar(List<ProductoPedido> ProductosPedidos)
        {
            double acumPrecio = 0;
            foreach (var prod in this.ProductosPedidos)
            {
                var precio = prod.Producto.Precio * prod.Cantidad;
                acumPrecio += precio;
            }
            return acumPrecio;
        }
    }
}
