using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Helpers;
using DataStructures.Interfaces;
using DataStructures.Helpers;
namespace DataStructures.ArrayBased
{
    public class BinarySearchTree<T>
    {
       /*
        Since using an array to add and remove element from a tree is not the typical use case and is not as efficient
       as with linked lists I am going to keep this class mostly for searching and traversing
        */

        public List<TreeNode<T>> tree;
        private int nodeCount;
        private IComparer comparer;
        
        public BinarySearchTree(List<TreeNode<T>> inTree)
        {//Already converted to a array
            tree = inTree;
        }

        public BinarySearchTree(TreeNode<T> root, Comparer comparer)
        {//Given a root node from a linked list we can recreate the tree in an arrays

            tree = new List<TreeNode<T>>();
            this.comparer = comparer;
            tree = TreeConverter<T>.GenerateToArrayFromRootNode(root,comparer);
            //nodeCount = getNodeCount();
        }

        public void BreadthFirstTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void DepthFirstTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T index)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        
        public void PostOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void PreOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public TreeNode<T> Search(int index)
        {//Search for item at a particular index in the array
            throw new NotImplementedException();
        }

        public TreeNode<T> Search(TreeNode<T> node)
        {//Search for a particular node
            throw new NotImplementedException();
        }
     

    }
}
