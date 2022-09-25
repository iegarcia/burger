using System;

namespace burger.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int Piso { get; set; }
        public char Depto { get; set; }
        public string Telefono { get; set; }
        public double Total { get; set; }
        public DateTime FechaDePedido { get; set; }
        public EstadoPedido.Estado EstadoPedido { get; set; }


    }
}