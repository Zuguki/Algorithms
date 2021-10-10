using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class MyStack<T> : IEnumerable<T>
    {
        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }
        
        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public int Count { get; private set; } = 0;
        public bool IsEmpty => Count == 0;
        private T[] _items;

        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                var largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);
                _items = largerArray;
            }

            _items[Count++] = item;
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _items[--Count] = default;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}