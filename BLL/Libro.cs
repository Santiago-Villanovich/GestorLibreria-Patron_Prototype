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
        public Genero genero { get; set; }
        public DateTime anioPubli { get; set; }
        public double precio { get; set; }
        public Editorial editorial { get; set; }
        public autor Autor { get; set; }

        public int stock { get; set; }

        public Libro() { }
        public Libro(string titulo,Genero _genero,DateTime anioPubli, double precio, int cantHojas, Editorial editorial, autor _autor,int _stock)
        {
            this.titulo = titulo;
            this.cantHojas = cantHojas;
            this.genero = _genero;
            this.anioPubli = anioPubli;
            this.precio = precio;
            this.editorial = editorial;
            this.Autor = _autor;
            this.stock = _stock;
        }
        public override string ToString()
        {
            return $"Titulo:{this.titulo} - Cantidad de paginas:{this.cantHojas} - Datos Editorial: {this.editorial.nombre},{this.editorial.direccion}";
        }


        //METODOS DE CLONE
        public object Clone() 
        {
            return this.MemberwiseClone();
        }

        public object ClonProfundo(object ObjProto)
        {
            Libro clone = (Libro)this.MemberwiseClone();
            clone.genero = new Genero(this.genero.id, this.genero.descripcion);
            clone.editorial = new Editorial(this.editorial.nombre, this.editorial.cuil, this.editorial.telefono, this.editorial.direccion);
            clone.Autor = new autor(this.Autor.codigo, this.Autor.nombre, this.Autor.apellido, this.Autor.nacionalidad, this.Autor.fecha_nacimiento);
            return clone;
        }

    }


    public class Genero //Clase genero de libro
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Genero(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
    }
}
