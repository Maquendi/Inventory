using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Venta
    {

        public int id_venta { get; set; }

        public DateTime fecha_venta { get; set; }

        public double total_venta { get; set; }

        public int id_vendedor { get; set; }

        public int id_cliente { get; set; }
    }
}
