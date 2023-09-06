using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPrototipo : ICloneable
    {
        object ClonSuperficial(object ObjProto);
        object ClonProfundo(object ObjProto);
    }
}
