using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class Libro:IPrototipo
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int cantHojas { get; set; }
        public Editorial editorial { get; set; }
        public List<autor> autores { get; set; }

        public int N_copia { get; set; }
        public Libro() { }
        public Libro(string titulo, int cantHojas, Editorial editorial)
        {
            this.titulo = titulo;
            this.cantHojas = cantHojas;
            this.editorial = editorial;
        }

        public object Clone()
        {
            return (Libro)this.MemberwiseClone();
        }

        public object ClonProfundo(object ObjProto)
        {
            Libro clone = (Libro)this.MemberwiseClone();
            clone.editorial = new Editorial(editorial.nombre,editorial.cuil,editorial.telefono,editorial.direccion);
            clone.titulo = String.Copy(titulo);
            return clone;
        }

        public override string ToString()
        {
            return $"Titulo:{this.titulo} - Cantidad de paginas:{this.cantHojas} - Datos Editorial: {this.editorial.nombre},{this.editorial.direccion}";
        }
    }
}
