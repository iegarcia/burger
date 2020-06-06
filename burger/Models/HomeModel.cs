using burger.Entidades;
using System.Collections.Generic;

namespace burger.Models
{
    public class HomeModel
    {
        public List<Producto> ListaProductos { get; set; }
        public List<Producto> ProductiosSeleccionados { get; set; }
    }
}