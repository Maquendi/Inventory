using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Persona
    {
        public int persona_id { get; set; }

        public string nombre{ get; set; }

        public string apellido { get; set; }

        public string cedula { get; set; }

        public string correo { get; set; }

        public Usuario usuario { get; set; }
    }
}
