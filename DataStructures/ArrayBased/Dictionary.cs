using DataStructures.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IDictionary = DataStructures.Interfaces;

namespace DataStructures.ArrayBased
{
    public class Dictionary<T> : IDictionary<T>
    {
        /*Normally you would have a generic type for a key, but just for simplicity here for now I am going to use integer values.
         Later I can add a helper for key generation and tracking.
         */

        IList<Node<T>>[] dictionary;
        int count;
        int highestKey;

        public Dictionary()
        {
            this.dictionary = new List<Node<T>>[10];

            // Initialize each list in the array
            for (int i = 0; i < this.dictionary.Length; i++)
            {
                this.dictionary[i] = new List<Node<T>>();
            }


            highestKey = 0;
            count = 0;
        }
        public Dictionary(IList<Node<T>>[] dictionary)
        {
            this.dictionary = dictionary;
            count = 0;
            foreach (var item in dictionary)
            {

                count += item.Count;

                foreach (Node<T> node in item)
                {
                    if (node.GetKey() > highestKey)
                    {
                        highestKey = node.GetKey();
                    }
                }
            }
        }

        public object? this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsFixedSize => true;

        public bool IsReadOnly => false;

        public int Count => this.count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();


        public int GetBucketIndex(int key)
        {
            if (key <= -1) throw new ArgumentNullException(key.ToString());

            return Math.Abs(key) % dictionary.Length;

        }

        public int GenerateKey()
        {//Sequential key, will always use 1+the last highest key;
            return ++highestKey;
        }

        public void Add(int key, T? value)
        {
            if (key <= -1) throw new ArgumentOutOfRangeException(key.ToString());

            int bucketIndex = GetBucketIndex(key);

            if (key > highestKey) { highestKey = key; }

            dictionary[bucketIndex].Add(new Node<T>(key, value));

            count++;
        }

        public void Clear()
        {
            foreach (var node in dictionary)
            {
                node.Clear();
            }

            count = 0;
        }

        public bool Contains(int key)
        {

            foreach (var bucket in dictionary)
            {
                foreach (var item in bucket)
                {
                    if (item.GetKey().Equals(key)) return true;
                }
            }

            return false;
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            int bucketIndex = GetBucketIndex(key);

            foreach (var item in dictionary[bucketIndex])
            {
                if (item is not null) { 
                    if (item.GetKey().Equals(key))
                    {
                        dictionary[bucketIndex].Remove(item);
                        count--;
                        return;
                    }
              }
            }
          
        }

        public ICollection GetKeys()
        {
            List<int> keys = new List<int>();

            foreach (var bucket in dictionary)
            {
                foreach (var item in bucket)
                {
                    keys.Add(item.GetKey());
                }
            }

            return keys;
        }

        public ICollection GetValues()
        {
            List<T> values = new List<T>();

            foreach (var bucket in dictionary)
            {
                foreach (var item in bucket)
                {
        
                    values.Add(item.GetValue());
                }
            }

            return values;
        }
        public int GetCount()
        {
            return this.count;
        }
    }

}
