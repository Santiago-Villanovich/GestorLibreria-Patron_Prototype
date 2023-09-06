using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Editorial
    {
        public string nombre { get; set; }
        public int cuil { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Editorial(int cuil)
        {
            this.cuil = cuil;
        }
    }
}
