using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class TreeNode<T> where T: IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public void Insert(T newValue)
        {
            var compare = newValue.CompareTo(Value);
            if (compare == 0)
                return;
            if (compare < 0)
            {
                if (Left == null)
                    Left = new TreeNode<T>(newValue);
                else
                    Left.Insert(newValue);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode<T>(newValue);
                else
                    Right.Insert(newValue);
            }
        }

        public TreeNode<T> Get(T value)
        {
            var compare = value.CompareTo(Value);
            if (compare == 0)
                return this;
            
            if (compare < 0)
            {
                if (Left != null)
                    return Left.Get(value);
            }
            else
            {
                if (Right != null)
                {
                    return Right.Get(value);
                }  
            }

            return null;
        }

        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();
            InnerTraverse(list);
            return list;
        }

        public T Min() => Left != null ? Left.Min() : Value;

        public T Max() => Right != null ? Right.Max() : Value;

        private void InnerTraverse(List<T> list)
        {
            Left?.InnerTraverse(list);

            list.Add(Value);

            Right?.InnerTraverse(list);
        }
    }
}