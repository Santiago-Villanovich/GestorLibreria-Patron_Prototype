using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPrototipo<T> : ICloneable
    {
        T ClonProfundo();
    }
}
