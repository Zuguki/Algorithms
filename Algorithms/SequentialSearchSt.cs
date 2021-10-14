using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class SequentialSearchSt<TKey, TValue>
    {
        private class Node
        {
            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }

            public TKey Key { get; }
            public TValue Value { get; set; }
            public Node Next { get; set; }
        }

        public SequentialSearchSt()
        {
            _comparer = EqualityComparer<TKey>.Default;
        }

        public SequentialSearchSt(IEqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public int Count { get; private set; }
        private Node _first;
        private readonly IEqualityComparer<TKey> _comparer;

        public bool TryGet(TKey key, out TValue value)
        {
            for (var node = _first; node != null; node = node.Next)
            {
                if (!_comparer.Equals(node.Key, key)) continue;
                
                value = node.Value;
                return true;
            } 

            value = default;
            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException();
            
            for (var node = _first; node != null; node = node.Next)
            {
                if (!_comparer.Equals(node.Key, key)) continue;
                
                node.Value = value;
                return;
            }

            _first = new Node(key, value, _first);
            Count++;
        }

        public bool Contains(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            for (var node = _first; node != null; node = node.Next)
            {
                if (_comparer.Equals(node.Key, key))
                    return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            if (_comparer.Equals(_first.Key, key))
            {
                _first = _first.Next;
                Count--;
                return true;
            }

            var previousNode = _first;
            for (var node = _first.Next; node != null; node = node.Next, previousNode = previousNode.Next)
            {
                if (_comparer.Equals(node.Key, key))
                {
                    previousNode.Next = node.Next;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (var node = _first; node != null; node = node.Next)
                yield return node.Key;
        }

        public IEnumerable<TValue> Values()
        {
            for (var node = _first; node != null; node = node.Next)
                yield return node.Value;
        }
    }
}