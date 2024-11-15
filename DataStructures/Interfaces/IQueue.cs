using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{   
    /*Typical queue interface. First in First Out... Items can only be inserted at the end and removed from the front*/
    public interface IQueue<T> : System.Collections.ICollection
    {
        public void Enqueue(T item);//Add as last item 
        public T Dequeue();//Removes first item

        public void Clear();//Remove all items

        public T Peek();//Return the value of the first item

        public bool IsEmpty();//Returns if there are no items

        public int Contains(T item);//Return the postion of the item if present and -1 if not;

        public string ToString();
    }
}
