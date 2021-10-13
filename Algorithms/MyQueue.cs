using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public MyQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
            _tail = 0;
        }
        
        public MyQueue(int capacity)
        {
            _queue = new T[capacity];
            _tail = 0;
        }

        private T[] _queue;
        private int _head;
        private int _tail;

        public void Enqueue(T item)
        {
            if (_tail == _queue.Length)
            {
                var largestArray = new T[Count * 2];
                Array.Copy(_queue, largestArray, Count);
                _queue = largestArray;
            }

            _queue[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            
            _queue[_head++] = default;
            if (IsEmpty) _head = _tail = 0;
        }

        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;
        
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = _head; i < _tail; i++)
                yield return _queue[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}