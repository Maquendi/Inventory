using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Detalle_Factura
    {
        public int id_detalle { get; set; }

        public int id_factura { get; set; }

        public int id_prod { get; set; }

        public int cantidad_prod { get; set; }
    }
}
