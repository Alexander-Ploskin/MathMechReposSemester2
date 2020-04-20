using System;
using System.Collections.Generic;
using System.Text;

namespace MySet
{
    /// <summary>
    /// Generic implementation of ISet, based on non-selfbalanced tree
    /// </summary>
    /// <typeparam name="T">Type of values in tree</typeparam>
    class MySet<T> : ISet<T>
    {
        private IComparer<T> comparer;

        public MySet(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count { get; }
        public bool IsReadOnly { get; }

        /// <summary>
        /// Elements of tree
        /// </summary>
        private class TreeElement
        {
            public TreeElement(TreeElement parent, T value)
            {
                Value = value;
                Parent = parent;
            }

            public T Value { get; }
            public TreeElement LeftChild { get; set; }
            public TreeElement RightChild { get; set; }
            public TreeElement Parent { get; set; }

            public bool IsLeaf() => LeftChild == null && RightChild == null;
        }

        private TreeElement root;

        /// <summary>
        /// Abbriviated comparing of tree element value and input value
        /// </summary>
        /// <param name="element">Element of tree</param>
        /// <param name="value">Input value</param>
        /// <returns>Result of comparing by comparer</returns>
        private int Compare(TreeElement element, T value) => comparer.Compare(element.Value, value);

        /// <summary>
        /// Adds new element to tree according to comparer
        /// </summary>
        /// <param name="item">New item in set</param>
        /// <returns>True if addition if succesful, false if item already contains in set</returns>
        public bool Add(T item)
        {
            if (root == null)
            {
                root = new TreeElement(null, item);
                return true;
            }

            var currentElement = root;
            while (true)
            {
                if (Compare(currentElement, item) > 0)
                {
                    if (currentElement.LeftChild == null)
                    {
                        currentElement.LeftChild = new TreeElement(currentElement, item);
                        return true;
                    }
                    currentElement = currentElement.LeftChild;
                }
                else if (Compare(currentElement, item) < 0)
                {
                    if (currentElement.RightChild == null)
                    {
                        currentElement.RightChild = new TreeElement(currentElement, item);
                        return true;
                    }
                    currentElement = currentElement.RightChild;
                }

                return false;
            }
        }

        
}
