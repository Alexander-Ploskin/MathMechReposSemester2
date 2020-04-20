using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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

        public int Count { get; set; }
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
                        Count++;
                        return true;
                    }
                    currentElement = currentElement.LeftChild;
                }
                else if (Compare(currentElement, item) < 0)
                {
                    if (currentElement.RightChild == null)
                    {
                        currentElement.RightChild = new TreeElement(currentElement, item);
                        Count++;
                        return true;
                    }
                    currentElement = currentElement.RightChild;
                }

                return false;
            }
        }

        /// <summary>
        /// Remove all items from collection
        /// </summary>
        /// <exception cref="NotSupportedException">Throws when set is readonly</exception>
        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            root = null;
            Count = 0;
        }

        /// <summary>
        /// Checks contains item in set or not
        /// </summary>
        /// <param name="item">Item, that you want to check</param>
        /// <returns>True if contains else false</returns>
        public bool Contains (T item)
        {
            if (root == null)
            {
                return false;
            }

            var currentElement = root;
            while (currentElement != null)
            {
                if (Compare(currentElement, item) == 0)
                {
                    return true;
                }
                else if (Compare(currentElement, item) > 0)
                {
                    currentElement = currentElement.LeftChild;
                }
                else
                {
                    currentElement = currentElement.RightChild;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies all elements of set to array, starts with expected index
        /// </summary>
        /// <param name="array">Array to copy</param>
        /// <param name="arrayIndex">Index, starts with, will set items</param>
        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        /// <summary>
        /// Remove from this all elements, that contains in other collection
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when other is null</exception>
        /// <param name="other">Collection</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
            }
        }

        public MyEnum GetEnumerator()
        {
            return new MyEnum(this);
        }

        public class MyEnum : IEnumerator
        {
            private MySet<T> set;
            private Stack<TreeElement> stack;

            public MyEnum(MySet<T> set)
            {
                stack = new Stack<TreeElement>();
                this.set = set;
                currentElement = set.root;
            }

            private TreeElement currentElement;

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public T Current
            {
                get
                {
                    return currentElement.Value;
                }
            }

            private bool moveRight = false;

            public bool MoveNext()
            {
                if (stack.Count != 0 || currentElement != null)
                {
                    if (moveRight)
                    {
                        currentElement = currentElement.RightChild;
                        moveRight = false;
                        stack.Push(currentElement);
                        MoveNext();
                    }
                    else
                    {
                        if (currentElement != null)
                        {
                            stack.Push(currentElement);
                            currentElement = currentElement.LeftChild;
                        }
                        else
                        {
                            currentElement = stack.Pop();
                            moveRight = true;
                        }
                    }

                    return true;
                }

                return false;
            }

            public void Reset()
            {
                currentElement = set.root;
                stack.Clear();
            }

        }

        /// <summary>
        /// Remove from set all elements, that doesn't contain in other collection
        /// </summary>
        /// <param name="other">Other collection</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    Remove(item);
                }
            }
        }

        /// <summary>
        /// Checks, is this subset of other collection
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True if all elements of this contains in other</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            int counterOfContainedElements = 0;

            foreach (var item in other)
            {
                if (Contains(item))
                {
                    counterOfContainedElements++;
                }
            }

            return counterOfContainedElements == Count;
        }

        /// <summary>
        /// Checks, is this proper subset of other collection
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True if all elements of this contains in other 
        /// and other has one or more eleents, that doesn't contain in this</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return IsSubsetOf(other);
                }
            }

            return false;
        }

        /// <summary>
        /// Checks, has this common element with other
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True, if has, else false</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        private TreeElement GetElementByValue(T value)
        {
            var currentElement = root;
            while (currentElement != null)
            {
                if (Compare(currentElement, value) == 0)
                {
                    return currentElement;
                }
                else if (Compare(currentElement, value) > 0)
                {
                    currentElement = currentElement.LeftChild;
                }
                else
                {
                    currentElement = currentElement.RightChild;
                }
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Sets new child to element
        /// </summary>
        /// <param name="element">Element, that gets new child</param>
        /// <param name="currentChild">Current child</param>
        /// <param name="newChild">newChild</param>
        private void SetNewChid(TreeElement element, TreeElement currentChild, TreeElement newChild)
        {
            if (currentChild == element.RightChild)
            {
                element.RightChild = newChild;
            }
            else if (currentChild == element.LeftChild)
            {
                element.LeftChild = newChild;
            }
        }

        /// <summary>
        /// Finds new child to element, that has two children
        /// </summary>
        /// <param name="element">Tree element</param>
        /// <returns>New child</returns>
        private TreeElement GetNewChild(TreeElement element)
        {
            var currentElement = element.RightChild;
            while (currentElement.LeftChild != null)
            {
                currentElement = currentElement.LeftChild;
            }

            return currentElement;
        }

        public bool Remove(T item)
        {
            try
            {
                var element = GetElementByValue(item);
                
                if (element.IsLeaf())
                {
                    SetNewChid(element.Parent, element, null);
                    return true;
                }
                else if (element.RightChild == null && element.LeftChild != null)
                {
                    SetNewChid(element.Parent, element, element.LeftChild);
                    return true;
                }
                else if (element.RightChild != null && element.LeftChild == null)
                {
                    SetNewChid(element.Parent, element, element.RightChild);
                    return true;
                }
                else
                {
                    var newChild = GetNewChild(element);
                    newChild.LeftChild = element.LeftChild;
                    newChild.RightChild = element.RightChild;
                    SetNewChid(element.Parent, element, newChild);
                    SetNewChid(newChild.Parent, newChild, null);
                    return true;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

    }
}
