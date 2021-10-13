using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class CircularQueueTests
    {
        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new CircularQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void IsEmpty_EnqueueOne_ReturnsFalse()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Count_EnqueueTwoItems_ReturnsTwo()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Count);
        }

        [Test]
        public void Count_EnqueueTwoItemsAndOneDequeue_ReturnsOne()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void Enqueue_EnqueueTenItemsAndCheckExpansion_ReturnsTen()
        {
            var queue = new CircularQueue<int>();
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
            Assert.AreEqual(10, queue.Count);
        }
        
        [Test]
        public void Dequeue_EmptyQueue_ReturnsIOE()
        {
            var queue = new CircularQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_EmptyQueue_ReturnsIOE()
        {
            var queue = new CircularQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Peek_EnqueueTwoItems_ReturnsFirstItem()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual(1, queue.Peek());
        }
        
        [Test]
        public void Peek_EnqueueTwoItemsAndDequeueFirst_ReturnsSecondItem()
        {
            var queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            Assert.AreEqual(2, queue.Peek());
        }
    }
}