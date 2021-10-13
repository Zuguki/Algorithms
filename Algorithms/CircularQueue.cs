using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        public CircularQueue()
        {
            const int defaultCapacity = 4;
            _queue = new T[defaultCapacity];
        }

        public CircularQueue(int capacity)
        {
            _queue = new T[capacity];
        }

        private T[] _queue;
        private int _head;
        private int _tail;

        public void Enqueue(T item)
        {
            if (Count == _queue.Length - 1)
            {
                var largestArray = new T[_queue.Length * 2];
                var countPriorResize = Count;
                Array.Copy(_queue, _head, largestArray, 0, _queue.Length - _head);
                Array.Copy(_queue, 0, largestArray, _queue.Length - _head, _tail);
                _queue = largestArray;

                _head = 0;
                _tail = countPriorResize;
            }

            _queue[_tail++] = item;

            if (_tail == _queue.Length)
                _tail = 0;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _queue[_head++] = default;

            if (IsEmpty)
                _head = _tail = 0;
            else if (_head == _queue.Length)
                _head = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _queue[_head];
        }

        public int Count => _head <= _tail ? _tail - _head : _tail + _queue.Length - _head;
        public bool IsEmpty => Count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            if (_head <= _tail)
            {
                for (var i = _head; i < _tail; i++)
                    yield return _queue[i];
            }
            else
            {
                for (var i = _head; i < _queue.Length; i++)
                    yield return _queue[i];
                for (var i = 0; i < _tail; i++)
                    yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}