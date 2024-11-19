using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
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
        private int count;
        private IComparer comparer;
        private List<TreeNode<int>> nodeInput;

        public BinarySearchTree(List<TreeNode<T>> treeList)
        {///Tree may not be in order but we must assume the root is index = 0. 
            tree = new List<TreeNode<T>>();
            comparer = Comparer<T>.Default; // Use default comparer for T
            count = 0;
            foreach (TreeNode<T> node in treeList) { Insert(node); }
        }

        public void Insert(TreeNode<T> node)
        {
           if(count == 0)
            {
                tree.Add(node);
                count++;
                return;
            }

            int pos = 0;
            while (tree[pos] is not null){
                if (comparer.Compare(tree[pos].GetValue(), node.GetValue()) > 0)
                {
                    pos = pos * 2 + 1;
                }
                else
                {
                    pos = pos * 2 + 2;
                }

                while(tree.Count <= pos)
                {
                    tree.Add(null);
                }
            }

            tree[pos] = node;
            count++;
            
        }

        public void BreadthFirstTraversal(Action<T> action)
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

        public void PreOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T index)
        {
            throw new NotImplementedException();
        }
        public TreeNode<T> Search(int index)
        {//Search for item at a particular index in the array
           if(index < 0) return null;

            return tree[index];
            
        }

        public int Search(TreeNode<T> node)
        {//Search for a particular node

            if (count == 0) return -1; 

            int pos = 0;
            while (tree[pos] is not null)
            {

                if (tree[pos].GetKey().Equals(node.GetKey()) && tree[pos].GetValue().Equals(node.GetValue()))
                {
                    return pos;
                }

                if (comparer.Compare(tree[pos].GetValue(), node.GetValue()) > 0)
                {
                    pos = pos * 2 + 1;
                }
                else
                {
                    pos = pos * 2 + 2;
                }
            }

            return -1;
        }

       

    }
}
