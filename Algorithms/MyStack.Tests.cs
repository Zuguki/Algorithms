using System;
using NUnit.Framework;

namespace Algorithms
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }
        
        [Test]
        public void IsEmpty_PushOneItem_ReturnsFalse()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Peek_PushOneItem_ReturnsItem()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsFirstItem()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }

        [Test]
        public void Pop_PushTwoItemsAndPop_ReturnsOne()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Pop_JustPop_ReturnsIOE()
        {
            var stack = new MyStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_JustPeek_ReturnsIOE()
        {
            var stack = new MyStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}