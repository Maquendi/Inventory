using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Producto
    {

        public int id_prod { get; set; }

        public string nombre_prod { get; set; }

        public string descripcion { get; set; }

        public double precio { get; set; }

    }
}
