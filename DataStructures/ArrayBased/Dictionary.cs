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
            //Default constructor

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

        
        /*
         * Each 'bucket' holds an array with all items with matching hash values. This function will find the hash value
         * matching the bucket the item should be put into based on its key.
         */
        public int GetBucketIndex(int key)
        {
            if (key <= -1) throw new ArgumentNullException(key.ToString());

            return Math.Abs(key) % dictionary.Length;

        }

        /*
         Generates a key sequentially based off the highest key value+1. The highest key value is tracked when we add new nodes or call generate Key;
         */
        public int GenerateKey()
        {
            return ++highestKey;
        }

        /*
         Adds an item to the dictionary using the key and value pair provided. Non-positive numbers will throw an error.
         */
        public void Add(int key, T? value)
        {
            if (key <= -1) throw new ArgumentOutOfRangeException(key + "");

            int bucketIndex = GetBucketIndex(key);

            if (key > highestKey) { highestKey = key; }

            dictionary[bucketIndex].Add(new Node<T>(key, value));

            count++;
        }

        /*
         Iterates of the dictionary and calls clear on each of its buckets
         */
        public void Clear()
        {
            foreach (var node in dictionary)
            {
                node.Clear();
            }

            count = 0;
        }

        /*
         Iterates over all buckets in the dictionary and checks if the item is contained in any
         */
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

        /*
         Removes the key value pairing based off of the provided key. If the key is not found nothing is removed and no error is thrown
         */
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


        /*
         Returns a collection of all keys in each bucket by iterating over each
         */
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

        /*
       Returns a collection of all values in each bucket by iterating over each
       */
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
