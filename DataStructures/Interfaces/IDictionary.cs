using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IDictionary<T>
    {
        void Add(int key, T? value);//Adds a key value pair to the Dictionary
        void Clear();//Clears all buckets and items from the Dictionary
        bool Contains(int key);//Returns true if the key is in one of the buckets
        IDictionaryEnumerator GetEnumerator();
        void Remove(int key);//Removes the item with the given key
    }
}
