using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace burger.Entidades
{
    public class EstadoPedido
    {
        public enum Estado
        {
            EN_PREPARACIÓN,
            CONFIRMADO,
            EN_CAMINO,
            ENTREGADO,
        }
    }
}