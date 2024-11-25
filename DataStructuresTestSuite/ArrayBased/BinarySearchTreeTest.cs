using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataStructures.ArrayBased;
using DataStructures.Helpers;

namespace DataStructuresTestSuite.ArrayBased
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [Test]
        public void CreateTree()
        {

            var treeArray = new TreeNode<int>[]
            {
                new TreeNode<int>(10, 10, null), // root at index 0
                new TreeNode<int>(5, 5, null),  // left child of root
                new TreeNode<int>(15, 15, null), // right child of root
                new TreeNode<int>(2, 2, null),  // left child of node at index 1
                new TreeNode<int>(7, 7, null),  // right child of node at index 1
                new TreeNode<int>(12, 12, null), // left child of node at index 2
                new TreeNode<int>(20, 20, null), // right child of node at index 2
                new TreeNode<int>(1, 1, null),  // left child of node at index 3
                new TreeNode<int>(3, 3, null),  // right child of node at index 3
                null,                            // left child of node at index 4
                null,                            // right child of node at index 4
                null,                            // left child of node at index 5
                null,                            // right child of node at index 5
                new TreeNode<int>(18, 18, null), // left child of node at index 6
                new TreeNode<int>(25, 25, null)  // right child of node at index 6
            };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            // Verify the structure
            int?[] expectedValues = { 10, 5, 15, 2, 7, 12, 20, 1, 3, null, null, null, null, 18, 25 };
            for (int i = 0; i < expectedValues.Length; i++)
            {
                int? actualValue = binaryTree.GetTree().ToArray()[i] is null ? null : binaryTree.GetTree().ToArray()[i].GetValue();
                int? expectedValue = expectedValues[i] is null ? null : expectedValues[i];

                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [Test]
        public void SearchByIndex()
        {

            var treeArray = new TreeNode<int>[]
           {
                new TreeNode<int>(10, 10, null), // root at index 0
                new TreeNode<int>(5, 5, null),  // left child of root
                new TreeNode<int>(15, 15, null), // right child of root
                new TreeNode<int>(2, 2, null),  // left child of node at index 1
                new TreeNode<int>(7, 7, null),  // right child of node at index 1
                new TreeNode<int>(12, 12, null), // left child of node at index 2
                new TreeNode<int>(20, 20, null), // right child of node at index 2
                new TreeNode<int>(1, 1, null),  // left child of node at index 3
                new TreeNode<int>(3, 3, null),  // right child of node at index 3
                null,                            // left child of node at index 4
                null,                            // right child of node at index 4
                null,                            // left child of node at index 5
                null,                            // right child of node at index 5
                new TreeNode<int>(18, 18, null), // left child of node at index 6
                new TreeNode<int>(25, 25, null)  // right child of node at index 6
           };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            // Verify search by index
            Assert.AreEqual(2, binaryTree.Search(3).GetValue()); // Index 3 should be node with value 4
            Assert.AreEqual(7, binaryTree.Search(4).GetValue()); // Index 4 should be node with value 5
            Assert.IsNull(binaryTree.Search(10)); // Index out of bounds
        }

        [Test]
        public void SearchByNode()
        {

            var treeArray = new TreeNode<int>[]
         {
                new TreeNode<int>(10, 10, null), // root at index 0
                new TreeNode<int>(5, 5, null),  // left child of root
                new TreeNode<int>(15, 15, null), // right child of root
                new TreeNode<int>(2, 2, null),  // left child of node at index 1
                new TreeNode<int>(7, 7, null),  // right child of node at index 1
                new TreeNode<int>(12, 12, null), // left child of node at index 2
                new TreeNode<int>(20, 20, null), // right child of node at index 2
                new TreeNode<int>(1, 1, null),  // left child of node at index 3
                new TreeNode<int>(3, 3, null),  // right child of node at index 3
                null,                            // left child of node at index 4
                null,                            // right child of node at index 4
                null,                            // left child of node at index 5
                null,                            // right child of node at index 5
                new TreeNode<int>(18, 18, null), // left child of node at index 6
                new TreeNode<int>(25, 25, null)  // right child of node at index 6
         };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            TreeNode<int> node = binaryTree.GetTree().ToArray()[5];

            // Verify search by node
            Assert.AreEqual(5, binaryTree.Search(node));
            Assert.AreEqual(-1, binaryTree.Search(new TreeNode<int>(6, 6, null))); // Node not in tree
        }

        [Test]
        public void GetChildren()
        {

            var treeArray = new TreeNode<int>[]
            {
                new TreeNode<int>(1, 1, null),  // root
                new TreeNode<int>(2, 2, null),  // left child
                new TreeNode<int>(3, 3, null),  // right child
                new TreeNode<int>(4, 4, null),  // left child of index 1
                new TreeNode<int>(5, 5, null)   // right child of index 1
            };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            // Verify children of node at index 1
            var children = binaryTree.GetChildren(2).ToList();
            Assert.AreEqual(1, children.Count);
            Assert.AreEqual(3, children[0]?.GetValue()); // Right child
        }

        [Test]
        public void InOrderTraversalFromNode()
        {

            var treeArray = new TreeNode<int>[]
            {
                new TreeNode<int>(10, 10, null),
                new TreeNode<int>(5, 5, null),
                new TreeNode<int>(15, 15, null),
                new TreeNode<int>(2, 2, null),
                new TreeNode<int>(7, 7, null),
                new TreeNode<int>(12, 12, null),
                new TreeNode<int>(20, 20, null),
                new TreeNode<int>(1, 1, null),
                new TreeNode<int>(3, 3, null),
                null,
                null,
                null,
                null,
                new TreeNode<int>(18, 18, null),
                new TreeNode<int>(25, 25, null)
            };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            List<TreeNode<int>> output = new List<TreeNode<int>>();
            binaryTree.InOrderTraversal(binaryTree.GetTree().ToList()[0], output);

            int[] expectedValues = { 1, 2, 3, 5, 7, 10, 12, 15, 18, 20, 25 };
            Assert.AreEqual(expectedValues, output.Select(node => node.GetValue()).ToArray());
        }

        [Test]
        public void PreOrderTraversalFromNode()
        {

            var treeArray = new TreeNode<int>[]
            {
                new TreeNode<int>(10, 10, null),
                new TreeNode<int>(5, 5, null),
                new TreeNode<int>(15, 15, null),
                new TreeNode<int>(2, 2, null),
                new TreeNode<int>(7, 7, null),
                new TreeNode<int>(12, 12, null),
                new TreeNode<int>(20, 20, null),
                new TreeNode<int>(1, 1, null),
                new TreeNode<int>(3, 3, null),
                null,
                null,
                null,
                null,
                new TreeNode<int>(18, 18, null),
                new TreeNode<int>(25, 25, null)
            };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            List<TreeNode<int>> output = new List<TreeNode<int>>();
            binaryTree.PreOrderTraversal(binaryTree.GetTree().ToList()[0], output);

            int[] expectedValues = { 10, 5, 2, 1, 3, 7, 15, 12, 20, 18, 25 };
            Assert.AreEqual(expectedValues, output.Select(node => node.GetValue()).ToArray());
        }

        [Test]
        public void PostOrderTraversalFromNode()
        {

            var treeArray = new TreeNode<int>[]
            {
                new TreeNode<int>(10, 10, null),
                new TreeNode<int>(5, 5, null),
                new TreeNode<int>(15, 15, null),
                new TreeNode<int>(2, 2, null),
                new TreeNode<int>(7, 7, null),
                new TreeNode<int>(12, 12, null),
                new TreeNode<int>(20, 20, null),
                new TreeNode<int>(1, 1, null),
                new TreeNode<int>(3, 3, null),
                null,
                null,
                null,
                null,
                new TreeNode<int>(18, 18, null),
                new TreeNode<int>(25, 25, null)
            };

            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>(treeArray.ToList());

            List<TreeNode<int>> output = new List<TreeNode<int>>();
            binaryTree.InOrderTraversal(binaryTree.GetTree().ToList()[0], output);

            int[] expectedValues = { 1, 2, 3, 5, 7, 10, 12, 15, 18, 20, 25 };
            Assert.AreEqual(expectedValues, output.Select(node => node.GetValue()).ToArray());
        }

    }
}
