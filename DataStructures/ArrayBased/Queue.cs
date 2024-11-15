using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Interfaces;




namespace DataStructures.ArrayBased
{
    public class Queue<T> : IQueue<T>
    {

        /*Typical queue implemention using an array based container.
        
        Insertion
        Enqueue(T item); = O(1) //Add at index [N-1] 
        
        Deletion
        Dequeue(); = O(N) //All items must be shifted after the first element is removed
        
        Search
        Peek(); = O(1) // Checks element [0]

 
 */

        private List<T> queue;

        public Queue()
        {
            this.queue = new List<T>();
        }

        public Queue(int capacity)
        {
            this.queue = new List<T>(capacity);
        }

        public int Count => this.queue.Count;

        
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();
        

        public void Clear()
        {
            this.queue.Clear();
        }

        public int Contains(T item)
        {

                return queue.IndexOf(item); // Will return the proper index if it is present or -1 if not

        }

        public void CopyTo(Array array, int index)
        {
            this.queue.ToArray().CopyTo(array, index);

        }

        public T Dequeue()
        {

            if (this.queue.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T itemRemoved = queue[0];
            queue.RemoveAt(0);

            return itemRemoved;

        }

        public void Enqueue(T item)
        {
            queue.Add(item);
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        public bool IsEmpty()
        {
            return !(queue.Count > 0);
        }

        public T Peek()
        {
            //Returns the value at the front of the queue
            if (this.queue.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return this.queue[0];
        }

        public string ToString()
        {
            String outputString = "";
            foreach (var item in this.queue)
            {
                outputString += item.ToString() + " ";
            }

            return outputString;
        }

    }
}
