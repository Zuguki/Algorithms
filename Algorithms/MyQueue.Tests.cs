using System;
using NUnit.Framework;

namespace Algorithms
{
    [TestFixture]
    public class MyQueueTests
    {
        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new MyQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void IsEmpty_EnqueueOne_ReturnsFalse()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Count_EnqueueTwoItems_ReturnsTwo()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual(queue.Count, 2);
        }

        [Test]
        public void Count_EnqueueTwoItemsAndOneDequeue_ReturnsOne()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            Assert.AreEqual(queue.Count, 1);
        }

        [Test]
        public void Enqueue_EnqueueTenItemsAndCheckExpansion_ReturnsTen()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            Assert.AreEqual(queue.Count, 10);
        }
    }
}