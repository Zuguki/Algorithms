using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class ChainHashSet<TKey, TValue>
    {
        public int Capacity { get; private set; }
        public int Count { get; private set; }
        
        private SequentialSearchSt<TKey, TValue>[] _chains;
        private const int DefaultCapacity = 4;

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            _chains = new SequentialSearchSt<TKey, TValue>[capacity];

            for (var i = 0; i < Capacity; i++)
                _chains[i] = new SequentialSearchSt<TKey, TValue>();
        }

        public ChainHashSet() : this(DefaultCapacity)
        { }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            var ind = Hash(key);
            if (_chains[ind].TryGet(key, out var val))
                return val;

            throw new ArgumentException();
        }

        public bool Contains(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            var ind = Hash(key);
            return _chains[ind].TryGet(key, out var _);
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException();

            var ind = Hash(key);
            if (_chains[ind].Contains(key))
            {
                _chains[ind].Remove(key);
                Count--;

                return true;
            }

            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null) throw new ArgumentNullException();
            if (val == null)
            {
                Remove(key);
                return;
            }

            if (Count >= 10 * Capacity) Resize(Capacity * 2);

            var ind = Hash(key);
            if (!_chains[ind].Contains(key))
                Count++;

            _chains[ind].Add(key, val);
        }

        private void Resize(int chains)
        {
            var temp = new ChainHashSet<TKey, TValue>(chains);

            for (var i = 0; i < Capacity; i++)
            {
                foreach (var key in _chains[i].Keys())
                {
                    if (_chains[i].TryGet(key, out var val))
                        temp.Add(key, val);
                }
            }

            Capacity = temp.Capacity;
            Count = temp.Count;
            _chains = temp._chains;
        }

        public IEnumerable<TKey> Keys()
        {
            var queue = new CircularQueue<TKey>();
            for (var i = 0; i < Capacity; i++)
            {
                foreach (var key in _chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }

            return queue;
        }
    }
}