using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Helpers
{
    public class TreeNode<T>
    {
        private int key;
        private T value;
        TreeNode<T> parent;
        List<TreeNode<T>> children;

        public TreeNode(int key, T value)
        {
            this.key = key;
            this.value = value;

        }

        // Getter for key
        public int GetKey()
        {
            return key;
        }

        // Setter for key
        public void SetKey(int key)
        {
            this.key = key;
        }

        // Getter for value
        public T GetValue()
        {
            return value;
        }

        // Setter for value
        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetParent(T parent)
        {
            this.parent = new TreeNode<T>(0, parent);
        }

        public void SetParent(TreeNode<T> parent)
        {
            this.parent = parent;
        }

        public void setChild(int index, TreeNode<T> value)
        {
            children[index] = value;
        }
        public void AddChild(T child)
        {
            children.Add(new TreeNode<T>(0, child));
        }

        public void AddChild(TreeNode<T> child)
        {
            children.Add(child);
        }

        public void RemoveChild(T child)
        {
            var nodeToRemove = children.Find(treeNode => treeNode.value.Equals(child));

            // Remove the node if found
            if (nodeToRemove != null)
            {
                children.Remove(nodeToRemove);
            }
        }

        public List<TreeNode<T>> GetChildren()
        {
            return children;
        }

        public bool HasChildren()
        {
            return children.Count > 0;
        }

    }
}
