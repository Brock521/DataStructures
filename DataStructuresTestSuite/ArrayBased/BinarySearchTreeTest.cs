using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.ArrayBased;
using DataStructures.Helpers;

namespace DataStructuresTestSuite.ArrayBased
{
    [TestFixture]
    public class BinarySearchTreeTest
    {

        [Test]
        public void ConvertNodeRootToArray()
        {
            TreeNode<int> root = new TreeNode<int>(1, 1, null);

            TreeNode<int> node2 = new TreeNode<int>(2, 2, root);
            TreeNode<int> node3 = new TreeNode<int>(3, 3, root);
            root.AddChild(node2);
            root.AddChild(node3);

            TreeNode<int> node4 = new TreeNode<int>(4, 4, node2);
            TreeNode<int> node5 = new TreeNode<int>(5, 5, node2);
            node2.AddChild(node4);
            node2.AddChild(node5);

            // Create the node list
            List<TreeNode<int>> nodeInput = new TreeConverter<int>().NodeBredFirstTraversal(root);

            // Pass the list into the BinarySearchTree constructor
            BinarySearchTree<int> treeArray = new BinarySearchTree<int>(nodeInput);

            foreach (TreeNode<int> node in treeArray.tree)
            {
                if (node == null)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(node.GetValue() + ", ");
                }
            }
        }

        [Test]
        public void SearchByIndex()
        {
            TreeNode<int> root = new TreeNode<int>(1, 1, null);

            TreeNode<int> node2 = new TreeNode<int>(2, 2, root);
            TreeNode<int> node3 = new TreeNode<int>(3, 3, root);
            root.AddChild(node2);
            root.AddChild(node3);

            TreeNode<int> node4 = new TreeNode<int>(4, 4, node2);
            TreeNode<int> node5 = new TreeNode<int>(5, 5, node2);
            node2.AddChild(node4);
            node2.AddChild(node5);

            // Create the node list
            List<TreeNode<int>> nodeInput = new TreeConverter<int>().NodeBredFirstTraversal(root);

            BinarySearchTree<int> treeArray = new BinarySearchTree<int>(nodeInput);

            Console.WriteLine(treeArray.Search(node4));
        }

        [Test]
        public void SearchByNode()
        {
            TreeNode<int> root = new TreeNode<int>(1, 1, null);

            TreeNode<int> node2 = new TreeNode<int>(2, 2, root);
            TreeNode<int> node3 = new TreeNode<int>(3, 3, root);
            root.AddChild(node2);
            root.AddChild(node3);

            TreeNode<int> node4 = new TreeNode<int>(4, 4, node2);
            TreeNode<int> node5 = new TreeNode<int>(5, 5, node2);
            node2.AddChild(node4);
            node2.AddChild(node5);

            // Create the node list
            List<TreeNode<int>> nodeInput = new TreeConverter<int>().NodeBredFirstTraversal(root);

            BinarySearchTree<int> treeArray = new BinarySearchTree<int>(nodeInput);

            Console.WriteLine(treeArray.Search(14).GetValue());
        }

        [Test]
        public void GetChildren()
        {
            TreeNode<int> root = new TreeNode<int>(1, 1, null);

            TreeNode<int> node2 = new TreeNode<int>(2, 2, root);
            TreeNode<int> node3 = new TreeNode<int>(3, 3, root);
            root.AddChild(node2);
            root.AddChild(node3);

            TreeNode<int> node4 = new TreeNode<int>(4, 4, node2);
            TreeNode<int> node5 = new TreeNode<int>(5, 5, node2);
            node2.AddChild(node4);
            node2.AddChild(node5);

            // Create the node list
            List<TreeNode<int>> nodeInput = new TreeConverter<int>().NodeBredFirstTraversal(root);

            BinarySearchTree<int> treeArray = new BinarySearchTree<int>(nodeInput);

            foreach(TreeNode<int> child in treeArray.GetChildren(2))
            {
                if(child is null)
                {
                    Console.Write("null, ");
                } else
                {
                    Console.Write(child.GetValue() + ", ");
                }
                
            }
        }

    }
}
