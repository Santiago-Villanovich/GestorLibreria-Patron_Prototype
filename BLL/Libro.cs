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
        public string genero { get; set; }
        public int anioPubli { get; set; }
        public double precio { get; set; }
        public Editorial editorial { get; set; }
        public List<autor> autores { get; set; }


        public Libro() { }
        public Libro(string titulo,string genero,int anioPubli, double precio, int cantHojas, Editorial editorial, List<autor> autores)
        {
            this.titulo = titulo;
            this.cantHojas = cantHojas;
            this.genero = genero;
            this.anioPubli = anioPubli;
            this.precio = precio;

            this.editorial = editorial;
            this.autores = autores;
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
