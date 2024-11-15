using DataStructures.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ArrayBased
{

    
    public class Stack<T> : IStack<T>
    {

     /*
     Stack implemention using an array as a container
       
        Insertion
        Push(T item); O(1)
        
        Deletion
        T Pop(); O(1)
        
        Search
        T Top(); O(1) 
        int Contains(T item); O(1)


     */

        List<T> stack;

        public Stack() { 
            stack = new List<T>();
        }

        public Stack(int size)
        {
            stack = new List<T>(size);
        }

        public int Count => stack.Count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Clear()
        {
            stack.Clear();
        }

        public int Contains(T item)
        {
            return stack.IndexOf(item);
        }

        public void CopyTo(Array array, int index)
        {
            stack.ToArray().CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        public bool IsEmpty()
        {
            return !(stack.Count > 0);
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T itemRemoved = stack[stack.Count-1];
            stack.RemoveAt(stack.Count - 1);

            return itemRemoved;
        }

        public void Push(T item)
        {
            stack.Add(item);
        }

        public T Top()
        {
            if (stack.Count == 0) { throw new IndexOutOfRangeException(); }

            return stack[stack.Count - 1];
        }
    }

}
