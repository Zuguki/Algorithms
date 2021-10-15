using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Bst<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public TreeNode<T> Get(T value) => _root?.Get(value);

        public T Min() => _root.Min();

        public T Max() => _root.Max();

        public void Insert(T value)
        {
            if (_root == null)
                _root = new TreeNode<T>(value);
            else
                _root.Insert(value);
        }

        public IEnumerable<T> TraverseInOrder() => _root != null ? _root.TraverseInOrder() : Enumerable.Empty<T>();

        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        private TreeNode<T> Remove(TreeNode<T> subTreeRoot, T value)
        {
            if (subTreeRoot == null)
                return null;

            var compareTo = value.CompareTo(subTreeRoot.Value);
            if (compareTo < 0)
                subTreeRoot.Left = Remove(subTreeRoot.Left, value);
            else if (compareTo > 0)
                subTreeRoot.Right = Remove(subTreeRoot.Right, value);
            else
            {
                if (subTreeRoot.Left == null)
                    return subTreeRoot.Right;
                if (subTreeRoot.Right == null)
                    return subTreeRoot.Left;

                subTreeRoot.Value = subTreeRoot.Right.Max();
                subTreeRoot.Right = Remove(subTreeRoot.Right, subTreeRoot.Value);
            }

            return subTreeRoot;
        }
    }
}