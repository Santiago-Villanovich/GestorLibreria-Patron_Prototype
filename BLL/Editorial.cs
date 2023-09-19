using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Editorial
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cuil { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Editorial(string _nombre,int _cuil,string _telefono,string _direccion)
        {
            
            this.cuil = _cuil;
            this.nombre = _nombre;
          this.telefono = _telefono;
          this.direccion = _direccion;
        }

        public Editorial()
        {

        }

        public Editorial(string _nombre, int _cuil)
        {
            this.cuil = _cuil;
            this.nombre = _nombre;
        }

        
    }
}
