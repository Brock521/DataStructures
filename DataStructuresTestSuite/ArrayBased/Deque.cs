using NUnit.Framework;
using DataStructures.ArrayBased;
using System;

namespace DataStructuresTestSuite.ArrayBased
{


    [TestFixture]
    public class DequeTests
    {
        // Test Enqueue and Peek
        [Test]
        public void TestEnqueueAndPeek()
        {
            Deque<int> deque = new Deque<int>();

            deque.Enqueue(10);
            deque.Enqueue(20);
            deque.Enqueue(30);

            // Peek should return the first item (as we add to the front)
            Assert.AreEqual(30, deque.Peek());
        }

        // Test Push and Top
        [Test]
        public void TestPushAndTop()
        {
            Deque<int> deque = new Deque<int>();

            deque.Push(10);
            deque.Push(20);
            deque.Push(30);

            // Top should return the last item (as we add to the back)
            Assert.AreEqual(30, deque.Top());
        }

        // Test Pop (removes from the back, same as Dequeue)
        [Test]
        public void TestPop()
        {
            Deque<int> deque = new Deque<int>();

            deque.Push(10);
            deque.Push(20);
            deque.Push(30);

            // Pop should return the last item (30)
            int poppedValue = deque.Pop();
            Assert.AreEqual(30, poppedValue);

            // After popping 30, Top should return 20
            Assert.AreEqual(20, deque.Top());
        }

        // Test Dequeue (removes from the back)
        [Test]
        public void TestDequeue()
        {
            Deque<int> deque = new Deque<int>();

            deque.Enqueue(10);
            deque.Enqueue(20);
            deque.Enqueue(30);

            // Dequeue should return the last item (10)
            int dequeuedValue = deque.Dequeue();
            Assert.AreEqual(10, dequeuedValue);

            // After dequeuing 10, Peek should return 20 (the next item)
            Assert.AreEqual(30, deque.Peek());
            Assert.AreEqual(20, deque.Top());
        }

        // Test Shift (removes from the front)
        [Test]
        public void TestShift()
        {
            Deque<int> deque = new Deque<int>();

            deque.Enqueue(10);
            deque.Enqueue(20);
            deque.Enqueue(30);

            // Shift should remove and return the first item (10)
            int shiftedValue = deque.Shift();
            Assert.AreEqual(30, shiftedValue);

            // After shifting 10, Peek should return 20
            Assert.AreEqual(20, deque.Peek());
        }

        // Test Contains (checks for presence of item)
        [Test]
        public void TestContains()
        {
            Deque<int> deque = new Deque<int>();

            deque.Enqueue(10);
            deque.Enqueue(20);
            deque.Enqueue(30);

            // Contains should return the index of the item (0-based index)
            Assert.AreEqual(1, deque.Contains(20));  // 20 is at index 1
            Assert.AreEqual(-1, deque.Contains(100)); // 100 is not in the deque
        }

        // Test IsEmpty
        [Test]
        public void TestIsEmpty()
        {
            Deque<int> deque = new Deque<int>();

            Assert.IsTrue(deque.IsEmpty()); // Deque should be empty initially

            deque.Enqueue(10);

            Assert.IsFalse(deque.IsEmpty()); // After adding an item, deque should not be empty
        }

        // Test Pop from empty deque
        [Test]
        public void TestPopEmptyDeque()
        {
            Deque<int> deque = new Deque<int>();

            // Trying to pop from an empty deque should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => deque.Pop());
        }

        // Test Dequeue from empty deque
        [Test]
        public void TestDequeueEmptyDeque()
        {
            Deque<int> deque = new Deque<int>();

            // Trying to dequeue from an empty deque should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => deque.Dequeue());
        }

        // Test Shift from empty deque
        [Test]
        public void TestShiftEmptyDeque()
        {
            Deque<int> deque = new Deque<int>();

            // Trying to shift from an empty deque should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => deque.Shift());
        }

        // Test Top from empty deque
        [Test]
        public void TestTopEmptyDeque()
        {
            Deque<int> deque = new Deque<int>();

            // Trying to peek from an empty deque should throw an IndexOutOfRangeException
            Assert.Throws<IndexOutOfRangeException>(() => deque.Top());
        }

        // Test Count
        [Test]
        public void TestCount()
        {
            Deque<int> deque = new Deque<int>();

            // Count should be 0 initially
            Assert.AreEqual(0, deque.Count);

            deque.Push(10);
            deque.Push(20);

            // Count should be 2 after pushing 2 items
            Assert.AreEqual(2, deque.Count);

            deque.Pop();

            // Count should be 1 after popping an item
            Assert.AreEqual(1, deque.Count);
        }

        // Test Clear
        [Test]
        public void TestClear()
        {
            Deque<int> deque = new Deque<int>();

            deque.Push(10);
            deque.Push(20);
            deque.Push(30);

            // Clear the deque
            deque.Clear();

            // After clearing, the deque should be empty
            Assert.IsTrue(deque.IsEmpty());
        }

        // Test CopyTo
        [Test]
        public void TestCopyTo()
        {
            Deque<int> deque = new Deque<int>();

            deque.Push(10);
            deque.Push(20);
            deque.Push(30);

            // Copy deque to an array
            int[] copiedArray = new int[deque.Count];
            deque.CopyTo(copiedArray, 0);

            // Check if the array has the same values as the deque
            Assert.AreEqual(10, copiedArray[0]);
            Assert.AreEqual(20, copiedArray[1]);
            Assert.AreEqual(30, copiedArray[2]);
        }
    }
}


