﻿using burger.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Models
{
    public class DeliveryModel
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int Piso { get; set; }
        public char Depto { get; set; }
        public string Telefono { get; set; }

    }
}