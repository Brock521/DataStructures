using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface ITree<T>
    {
        // Inserts a value at a specific index/position.
        void Insert(T item);

        // Removes a specified item.
        void Remove(T item);

        // Removes a value at a specific index/position.
        void Remove(int index);

        // Searches for a value by its index/position.
        int Search(T index);

        // Traverses the tree in a depth-first manner.
        void DepthFirstTraversal(Action<T> action);

        // Traverses the tree in a breadth-first manner.
        void BreadthFirstTraversal(Action<T> action);

        // Performs an in-order traversal of the binary tree.
        void InOrderTraversal(Action<T> action);

        // Performs a pre-order traversal of the binary tree.
        void PreOrderTraversal(Action<T> action);

        // Performs a post-order traversal of the binary tree.
        void PostOrderTraversal(Action<T> action);

        // Gets the children of a specific node.
        IEnumerable<T> GetChildren(T index);

        // Gets the root value of the tree.
        T GetRoot();




    }
}
