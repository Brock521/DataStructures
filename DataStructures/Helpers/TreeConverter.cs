using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Helpers
{
    public static class TreeConverter<T>
    {
        public static List<TreeNode<T>> GenerateToArrayFromRootNode(TreeNode<T> root, Comparer comparer)
        {       
                if (root == null) throw new ArgumentNullException(nameof(root));

                // List to represent the array-based tree
                List<TreeNode<T>> generatedTree = new List<TreeNode<T>>();
                Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

                // Start with the root node
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    TreeNode<T> currentNode = queue.Dequeue();

                    // Add the current node to the array-based tree
                    generatedTree.Add(currentNode);

                    // Get the children of the current node
                    List<TreeNode<T>> childrenNodes = currentNode.GetChildren();

                    // Validate the number of children
                    if (childrenNodes.Count > 2)
                    {
                        throw new InvalidDataException("A node has more than two children, which is not allowed for a binary tree.");
                    }

                    // Add children to the queue (for breadth-first traversal)
                    foreach (var child in childrenNodes)
                    {
                        queue.Enqueue(child);
                    }

                    // Ensure the left and right children are ordered correctly if needed
                    if (childrenNodes.Count == 2)
                    {
                        if (comparer.Compare(childrenNodes[0].GetValue(), childrenNodes[1].GetValue()) > 0)
                        {
                            currentNode.setChild(1, childrenNodes[1]);
                            currentNode.setChild(0, childrenNodes[0]);
                        }
                        else
                        {
                            currentNode.setChild(0, childrenNodes[0]);
                            currentNode.setChild(1, childrenNodes[1]);
                        }
                    }
                    else if (childrenNodes.Count == 1)
                    {
                        currentNode.setChild(0, childrenNodes[0]);
                        currentNode.setChild(1, null);
                    }
                }

                return generatedTree;
            }
        

    }
}
