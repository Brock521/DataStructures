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
        void Add(int key, T? value);
        void Clear();
        bool Contains(int key);
        IDictionaryEnumerator GetEnumerator();
        void Remove(int key);
    }
}
