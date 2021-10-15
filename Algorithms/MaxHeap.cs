using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public bool IsFull => Count == _heap.Length;
        
        private T[] _heap;
        private const int DefaultCapacity = 4;

        public MaxHeap() : this(DefaultCapacity)
        { }

        public MaxHeap(int capacity)
        {
            _heap = new T[capacity];
        }

        public void Insert(T value)
        {
            if (IsFull)
                Resize(_heap.Length * 2);

            _heap[Count] = value;
            Swim(Count++);
        }

        private void Resize(int newHeapLength)
        {
            var tmpHeap = new T[newHeapLength];
            Array.Copy(_heap, 0, tmpHeap, 0, _heap.Length);
            _heap = tmpHeap;
        }

        private void Swim(int itemIndex)
        {
            var newValue = _heap[itemIndex];
            while (itemIndex > 0 && IsParentLess(itemIndex))
            {
                _heap[itemIndex] = GetParent(itemIndex);
                itemIndex = GetParentIndex(itemIndex);
            }

            _heap[itemIndex] = newValue;

            bool IsParentLess(int index) => newValue.CompareTo(GetParent(index)) > 0;
        }

        public IEnumerable<T> Values()
        {
            for (var ind = 0; ind < Count; ind++)
            {
                yield return _heap[ind];
            }
        }

        private T GetParent(int index) => _heap[GetParentIndex(index)];

        private int GetParentIndex(int index) => (index - 1) / 2;
    }
}