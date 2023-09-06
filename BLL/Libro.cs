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
        public string titulo { get; set; }
        public int cantHojas { get; set; }
        public Editorial editorial { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public object ClonProfundo(object ObjProto)
        {
            Libro clone = (Libro)this.MemberwiseClone();
            clone.editorial = new Editorial(editorial.cuil);
            clone.titulo = String.Copy(titulo);
            return clone;
        }

        public object ClonSuperficial(object ObjProto)
        {
            return (Libro)this.MemberwiseClone();
        }
    }
}
