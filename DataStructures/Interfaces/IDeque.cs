using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IDeque<T> : IStack<T>, IQueue<T>
    {
       public T Shift(); //Removes the first item
    }
}
