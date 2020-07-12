using burger.Entidades;
using System;

namespace burger.Models
{
    public class AdminModel
    {
        public string UsuarioLogueado { get; set; }
        public ProductoEstadistica[] productosMasVendidos { get; set; }
        public int pedidosRealizados { get; set; }
    }
}

