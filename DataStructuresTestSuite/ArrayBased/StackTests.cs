using NUnit.Framework;
using DataStructures.ArrayBased;
using System;

namespace DataStructuresTestSuite.ArrayBased
{
    [TestFixture]
    public class StackTests
    {
        // Test Push and Top
        [Test]
        public void TestPushAndTop()
        {
            DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Top should return the last pushed item
            Assert.AreEqual(30, stack.Top());
        }

        // Test Pop
        [Test]
        public void TestPop()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Pop should return the last pushed item (30)
            int poppedValue = stack.Pop();
            Assert.AreEqual(30, poppedValue);

            // After popping 30, Top should now return 20
            Assert.AreEqual(20, stack.Top());
        }

        // Test Contains
        [Test]
        public void TestContains()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Contains should return the index of the item (0-based index)
            Assert.AreEqual(1, stack.Contains(20));  // 20 is at index 1
            Assert.AreEqual(-1, stack.Contains(100)); // 100 is not in the stack
        }

        // Test IsEmpty
        [Test]
        public void TestIsEmpty()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            Assert.IsTrue(stack.IsEmpty()); // Stack should be empty initially

            stack.Push(10);

            Assert.IsFalse(stack.IsEmpty()); // After pushing an item, stack should not be empty
        }

        // Test Pop from empty stack
        [Test]
        public void TestPopEmptyStack()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            // Trying to pop from an empty stack should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }

        // Test Top from empty stack
        [Test]
        public void TestTopEmptyStack()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            // Trying to peek from an empty stack should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => stack.Top());
        }

        // Test Count
        [Test]
        public void TestCount()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            // Count should initially be 0
            Assert.AreEqual(0, stack.Count);

            stack.Push(10);
            stack.Push(20);

            // Count should be 2 after pushing 2 items
            Assert.AreEqual(2, stack.Count);

            stack.Pop();

            // Count should be 1 after popping an item
            Assert.AreEqual(1, stack.Count);
        }

        // Test Clear the stack (using CopyTo method as part of the test)
        [Test]
        public void TestClearAndCopyTo()
        {
           DataStructures.ArrayBased.Stack<int> stack = new DataStructures.ArrayBased.Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Copy stack to an array
            int[] copiedArray = new int[stack.Count];
            stack.CopyTo(copiedArray, 0);

            // Check if the array has the same values as the stack
            Assert.AreEqual(10, copiedArray[0]);
            Assert.AreEqual(20, copiedArray[1]);
            Assert.AreEqual(30, copiedArray[2]);

            // Clear the stack
            stack.Clear();

            // After clearing, the stack should be empty
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
