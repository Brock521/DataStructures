using DataStructures.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ArrayBased
{
    public class Deque<T> : IDeque<T>
    {

        /*
        This Deque which is a combination stack and Queue implemention using an array, with an added shift function to remove the first element. 
        Essentially all operation are done on either end of the container.
    

          Insertion
          Enqueue(T item); = O(N) Item is added to the front. All existing items must be shifted.
          Push(T item); O(1) Item is inserted as the final element.

          Deletion
          Dequeue(); = O(1) Last item in the dequeue is removed
          Pop(); = O(1) Identical to Dequeue. But must be implemented because of the stack interface
          Shift(); = O(N) item is removed from the front so all existing items must be shifted to fill the space

          Search
          Peek(); = O(1) // Checks element [0]
          Top(); = O(1) // Checks the element at [N-1];

   */

        private List<T> deque;

        public Deque()
        {
            this.deque = new List<T>();
        }

        public Deque(int capacity)
        {
            this.deque = new List<T>(capacity);
        }

        public int Count => this.deque.Count;


        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();


        public void Clear()
        {
            this.deque.Clear();
        }

        public int contains(T item)
        {

            return deque.IndexOf(item); // Will return the proper index if it is present or -1 if not

        }

        public void CopyTo(Array array, int index)
        {
            this.deque.ToArray().CopyTo(array, index);

        }

        public T Dequeue()
        {

            if (this.deque.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T itemRemoved = deque[deque.Count - 1];
            deque.RemoveAt(deque.Count-1);

            return itemRemoved;

        }

        public void Enqueue(T item)
        {
            deque.Insert(0,item);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return deque.GetEnumerator();
        }

        public bool IsEmpty()
        {
            return !(deque.Count > 0);
        }

        public T Peek()
        {
            //Returns the value at the front of the deque
            if (this.deque.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return deque[0];
        }

        public string ToString()
        {
            String outputString = "";
            foreach (var item in this.deque)
            {
                outputString += item.ToString() + " ";
            }

            return outputString;
        }
        public T Pop()
        {
            if (deque.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T itemRemoved = deque[deque.Count - 1];
            deque.RemoveAt(deque.Count - 1);

            return itemRemoved;
        }

        public void Push(T item)
        {
            deque.Add(item);
        }

        public T Top()
        {
            if (deque.Count == 0) { throw new IndexOutOfRangeException(); }

            return deque[deque.Count - 1];
        }

        public int Contains(T item)
        {
            return deque.IndexOf(item);
        }

        public T Shift()
        {
            if (deque.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T itemRemoved = deque[0];
            deque.RemoveAt(0);

            return itemRemoved;
        }
    }
}
