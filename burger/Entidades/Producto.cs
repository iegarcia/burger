﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}