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

        private enum Position
        {
            Right,
            Left
        }

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

        public T Peek()
        {
            if (_heap == null)
                throw new InvalidOperationException();

            return _heap[0];
        }

        public T Remove()
        {
            return Remove(0);
        }

        public T Remove(int index)
        {
            if (_heap == null)
                throw new InvalidOperationException();

            var removedValue = _heap[index];
            _heap[index] = _heap[Count - 1];
            if (index == 0 || _heap[index].CompareTo(GetParent(index)) < 0)
                Sink(index);
            else
                Swim(index);

            Count--;
            return removedValue;
        }

        public IEnumerable<T> Values()
        {
            for (var ind = 0; ind < Count; ind++)
            {
                yield return _heap[ind];
            }
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
        
        private void Sink(int itemIndex)
        {
            var lastHeapIndex = Count - 1;
            while (itemIndex <= lastHeapIndex)
            {
                var leftChildIndex = GetChildIndex(Position.Left, itemIndex);
                var rightChildIndex = GetChildIndex(Position.Right, itemIndex);
                
                if (leftChildIndex < lastHeapIndex)
                    break;

                var childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThan(childIndexToSwap))
                    Exchange(itemIndex, childIndexToSwap);
                else
                    break;

                itemIndex = childIndexToSwap;
            }

            bool SinkingIsLessThan(int childToSwap) => _heap[itemIndex].CompareTo(_heap[childToSwap]) < 0;

            void Exchange(int leftIndex, int rightIndex)
            {
                (_heap[rightIndex], _heap[leftIndex]) = (_heap[leftIndex], _heap[rightIndex]);
            }
            
            int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
            {
                int childToSwap;
                
                if (rightChildIndex > lastHeapIndex)
                    childToSwap = leftChildIndex;
                else
                {
                    var compare = _heap[leftChildIndex].CompareTo(_heap[rightChildIndex]);
                    childToSwap = compare > 0 ? leftChildIndex : rightChildIndex;
                }

                return childToSwap;
            }
        }

        private int GetChildIndex(Position position, int itemIndex)
        {
            if (position == Position.Left)
                return 2 * itemIndex + 1;

            return 2 * itemIndex + 2;
        }

        private void Resize(int newHeapLength)
        {
            var tmpHeap = new T[newHeapLength];
            Array.Copy(_heap, 0, tmpHeap, 0, _heap.Length);
            _heap = tmpHeap;
        }
        
        private T GetParent(int index) => _heap[GetParentIndex(index)];

        private int GetParentIndex(int index) => (index - 1) / 2;
    }
}