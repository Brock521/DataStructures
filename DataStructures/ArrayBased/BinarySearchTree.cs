using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.ArrayBased
{
    public class BinarySearchTree<T> 
    {
        /*
         Since using an array to add and remove element from a tree is not the typical use case and is not as efficient
        as with linked lists I am going to keep this class mostly for searching and traversing
         */

        private List<TreeNode<T>> tree;
        private int count;
        private IComparer comparer;
        private List<TreeNode<int>> nodeInput;

        public BinarySearchTree(List<TreeNode<T>> treeList)
        {///Tree may not be in order but we must assume the root is index = 0, we will re-create 
            tree = new List<TreeNode<T>>();
            comparer = Comparer<T>.Default; // Use default comparer for T
            count = 0;
            foreach (TreeNode<T> node in treeList) { Insert(node); }
        }

        public BinarySearchTree(List<TreeNode<T>> treeList, Comparer<T> comparer)
        {///Tree may not be in order but we must assume the root is index = 0, we will re-create 
            tree = new List<TreeNode<T>>();
            this.comparer = comparer; // Use default comparer for T
            count = 0;
            foreach (TreeNode<T> node in treeList) { Insert(node); }
        }

        public void Insert(TreeNode<T> node)
        {
            if (count == 0)
            {
                tree.Add(node);
                count++;
                return;
            } else if(node is null)
            {
                return;
            }

            int pos = 0;
            while (tree[pos] is not null)
            {
                if (comparer.Compare(tree[pos].GetValue(), node.GetValue()) > 0)
                {
                    pos = pos * 2 + 1;
                }
                else
                {
                    pos = pos * 2 + 2;
                }

                while (tree.Count <= pos)
                {
                    tree.Add(null);
                }
            }

            tree[pos] = node;
            count++;

        }

        public void InOrderTraversal(TreeNode<T> node, List<TreeNode<T>> traversalArray)
        {
            if (node == null) return; // Base case

            int nodePos = Search(node); // Find the position of the current node in the tree

            // Check if the left child exists and is not outside the bounds of the array
            if (nodePos * 2 + 1 < tree.Count && tree[nodePos * 2 + 1] != null)
                InOrderTraversal(tree[nodePos * 2 + 1], traversalArray);

            // Add the current node
            traversalArray.Add(node);

            // Check if the right child exists and is not outside the bounds of the array
            if (nodePos * 2 + 2 < tree.Count && tree[nodePos * 2 + 2] != null) 
                InOrderTraversal(tree[nodePos * 2 + 2], traversalArray);
        }


        public void PostOrderTraversal(TreeNode<T> node, List<TreeNode<T>> traversalArray)
        {


            if (node == null) return; // Base case

            int nodePos = Search(node); // Find the position of the current node in the tree

            if (nodePos * 2 + 1 < tree.Count && tree[nodePos * 2 + 1] != null)
                PostOrderTraversal(tree[nodePos * 2 + 1], traversalArray);


            if (nodePos * 2 + 2 < tree.Count && tree[nodePos * 2 + 2] != null)
                PostOrderTraversal(tree[nodePos * 2 + 2], traversalArray);


            traversalArray.Add(node);
        }

        public void PreOrderTraversal(TreeNode<T> node, List<TreeNode<T>> traversalArray)
        {

            if (node == null) return; // Base case

            int nodePos = Search(node); // Find the position of the current node in the tree

            traversalArray.Add(node);

            if (nodePos * 2 + 1 < tree.Count && tree[nodePos * 2 + 1] != null)
                PreOrderTraversal(tree[nodePos * 2 + 1], traversalArray);


            if (nodePos * 2 + 2 < tree.Count && tree[nodePos * 2 + 2] != null)
                PreOrderTraversal(tree[nodePos * 2 + 2], traversalArray);
        }

        public IEnumerable<TreeNode<T>> GetChildren(int index)
        {
            List<TreeNode<T>> children = new List<TreeNode<T>>();

            if (index * 2 + 1 < tree.Count && tree[index * 2 + 1] != null)
                children.Add(tree[index * 2 + 1]);
            if (index * 2 + 2 < tree.Count && tree[index * 2 + 2] != null)
                children.Add(tree[index * 2 + 2]);

            return children;
        }

        public TreeNode<T> Search(int index)
        {//Search for item at a particular index in the array
            if (index < 0) return null;

            return tree[index];

        }

        public int Search(TreeNode<T> node)
        {//Search for a particular nodes index

            if (count == 0 || node is null) return -1;

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

        public IEnumerable<TreeNode<T>> GetTree()
        {
            return this.tree;
        }

        public int Count()
        {
            return this.count;
        }


    }
}
