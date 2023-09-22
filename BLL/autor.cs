using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class autor
    {
        public int codigo { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nacionalidad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string NombreCompleto { get; set; }

        public autor() { }
        public autor(int codigo, string nombre, string apellido, string nacionalidad, DateTime fecha_Nacimiento)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.Fecha_Nacimiento = fecha_Nacimiento;
            this.NombreCompleto = nombre + " " + apellido;
        }
        public void SetNombreCompleto()
        {
            NombreCompleto = this.nombre + " " + this.apellido;
        }
    }
}
