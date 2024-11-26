using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        private int key;
        private T value;

        public Node(int key, T value)
        {

            this.key = key;
            this.value = value;

        }

       public int GetKey() { return key; }
        public T GetValue() { return this.value; }

        public void SetKey(int key) { this.key = key; }

        public void SetValue(T value) { this.value = value; }


    }
}
