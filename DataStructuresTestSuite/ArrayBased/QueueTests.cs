using NUnit.Framework;
using DataStructures.ArrayBased;

namespace DataStructuresTestSuite.ArrayBased
{

    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void TestEnqueueAndToString()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            intQueue.Enqueue(10);
            intQueue.Enqueue(20);
            intQueue.Enqueue(30);

            Assert.AreEqual("10 20 30 ", intQueue.ToString());
        }

        [Test]
        public void TestPeek()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            intQueue.Enqueue(10);
            Assert.AreEqual(10, intQueue.Peek());
        }

        [Test]
        public void TestDequeue()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            intQueue.Enqueue(10);
            intQueue.Enqueue(20);

            int dequeuedItem = intQueue.Dequeue();
            Assert.AreEqual(10, dequeuedItem);
            Assert.AreEqual("20 ", intQueue.ToString());
        }

        [Test]
        public void TestIsEmpty()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            Assert.IsTrue(intQueue.IsEmpty());

            intQueue.Enqueue(10);
            Assert.IsFalse(intQueue.IsEmpty());
        }

        [Test]
        public void TestClear()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            intQueue.Enqueue(10);
            intQueue.Enqueue(20);
            intQueue.Clear();

            Assert.IsTrue(intQueue.IsEmpty());
            Assert.AreEqual(0, intQueue.Count);
        }

        [Test]
        public void TestCopyTo()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            intQueue.Enqueue(100);
            intQueue.Enqueue(200);
            intQueue.Enqueue(300);

            int[] copiedArray = new int[intQueue.Count];
            intQueue.CopyTo(copiedArray, 0);

            Assert.AreEqual(new[] { 100, 200, 300 }, copiedArray);
        }

        [Test]
        public void TestDequeueFromEmptyQueueThrowsException()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            Assert.Throws<IndexOutOfRangeException>(() => intQueue.Dequeue());
        }

        [Test]
        public void TestPeekFromEmptyQueueThrowsException()
        {
            var intQueue = new DataStructures.ArrayBased.Queue<int>();
            Assert.Throws<IndexOutOfRangeException>(() => intQueue.Peek());
        }
    }
}
