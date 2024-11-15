using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    /*Typical stack interface. First in first out... Items are added to the front/top and removed from the front/top only*/
    public interface IStack<T> : System.Collections.ICollection
    {
        public void Push(T item); // Add item to the top of the stack
        public T Pop();//Remove and return the item from the top of the stack
        public T Top();//Return the item at the top of the stack
        public int Contains(T item);//Returns true when the item passed in is present, returns its position as an int.
        public bool IsEmpty();//Returns true when not value is in the stack
        public void Clear();//Removes all items

    }
}
