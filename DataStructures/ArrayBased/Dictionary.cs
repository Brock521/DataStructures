using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.ArrayBased
{
    public class Dictionary<T> : IDictionary
    {

        IList<T> dictionary;
        int count;
        public Dictionary() {
            this.dictionary = new List<T>(); 
            count = 0; 
        }
        public Dictionary(IList<T> dictionary)
        {
            this.dictionary = dictionary;
            count = dictionary.Count(item => item is not null);
        }
        public object? this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Add(object key, object? value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class DictNode
        {
            private int key;
            private T value;

            public DictNode(int key, T value)
            {

                this.key = key; 
                this.value = value;

            }

            int getKey() {return key;}
            T getValue() { return this.value; }

            void setKey(int key) { this.key = key;}

            void setValue(T value) { this.value = value; }


        }


    }
