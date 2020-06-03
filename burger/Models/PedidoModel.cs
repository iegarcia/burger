using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class PedidoModel
    {
        public List<Producto> ProductosPedidos { get; set; }
        public DeliveryModel DatosConsumidor { get; set; }


        public double Sumar(List<Producto> ProductosPedidos)
        {
            double acumPrecio = 0;
            foreach (var prod in this.ProductosPedidos)
            {
                var precio = prod.Total;
                acumPrecio += precio;
            }
            return acumPrecio;
        }
    }
}
