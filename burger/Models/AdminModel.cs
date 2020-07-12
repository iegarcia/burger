﻿using burger.Entidades;
using System;

namespace burger.Models
{
    public class AdminModel
    {
        public string UsuarioLogueado { get; set; }
        public ProductoEstadistica[] ProductosMasVendidos { get; set; }
        public int PedidosRealizados { get; set; }
    }
}

