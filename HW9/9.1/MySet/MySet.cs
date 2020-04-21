using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.Http.Headers;

namespace MySet
{
    /// <summary>
    /// Generic implementation of ISet, based on non-selfbalanced tree
    /// </summary>
    /// <typeparam name="T">Type of values in tree</typeparam>
    public class MySet<T> : ISet<T>
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

            public T Value { get; set; }
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
                Count++;
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
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Implementation of method in ICollection
        /// </summary>
        /// <param name="item"></param>
        void ICollection<T>.Add(T item)
        {
            Add(item);
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
        /// <exception cref="ArgumentException">Throws when array doesn't have enough place</exception>
        public void CopyTo(T[] array, int arrayIndex)
        { 
            void CopySubtreeToArray(TreeElement element)
            {
                if (element == null)
                {
                    return;
                }
                CopySubtreeToArray(element.LeftChild);
                array[arrayIndex] = element.Value;
                arrayIndex++;
                CopySubtreeToArray(element.RightChild);
            }

            CopySubtreeToArray(root);
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

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>MyEnum</returns>
        public MyEnum GetEnumerator()
        {
            return new MyEnum(this);
        }

        /// <summary>
        /// Implementation for the GetEnumerator method in IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Implementation for the GetEnumerator in IEnumerable<T>
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        /// <summary>
        /// Enumerator of tree. In-order tree traversal
        /// </summary>
        public class MyEnum : IEnumerator<T>
        {
            private MySet<T> set;
            private T[] array;
            private int index = -1;

            /// <summary>
            /// Implementation of method IDisposable
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            public MyEnum(MySet<T> set)
            {
                this.set = set;
                array = new T[set.Count];
                set.CopyTo(array, 0);
            }

            /// <summary>
            /// Implementation of IEnumerator.Current
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// <summary>
            /// Current item in traversal
            /// </summary>
            public T Current
            {
                get
                {
                    return array[index];
                }
            }

            /// <summary>
            /// Move to next item
            /// </summary>
            /// <returns>True, if set has not used items, else false</returns>
            public bool MoveNext()
            {
                index++;
                return index < set.Count;
            }

            /// <summary>
            /// To first item in traversal
            /// </summary>
            public void Reset()
            {
                index = 0;
            }

        }

        /// <summary>
        /// Remove from set all elements, that doesn't contain in other collection
        /// </summary>
        /// <param name="other">Other collection</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);

            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            var listToRemove = new List<T>();
            foreach (var item in this)
            {
                if (!helpSet.Contains(item))
                {
                    listToRemove.Add(item);
                }
            }

            foreach (var item in listToRemove)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Checks is this subset of other 
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True if all items of this contains in other, else false;</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);

            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            foreach (var item in this)
            {
                if (!helpSet.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks is this proper subset of other 
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True if all items of this contains in other and 
        /// other has one or more not common items, else false</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);

            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            foreach (var item in this)
            {
                if (!helpSet.Contains(item))
                {
                    return false;
                }
            }

            return helpSet.Count > Count;
        }

        /// <summary>
        /// Checks, is this a superset of other
        /// </summary>
        /// <param name="other">Other collection</param>
        /// <returns>True if all items of other contains in this, else false</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks, is 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);

            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            return helpSet.IsProperSubsetOf(this);
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

        /// <summary>
        /// Find tree element by value
        /// </summary>
        /// <param name="value">Value, that you want to find</param>
        /// <returns>Reference to node of tree</returns>
        /// <exception cref="ArgumentException">Throws when tree hasn't node with that value</exception>
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

            if (newChild != null)
            {
                newChild.Parent = element;
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

        /// <summary>
        /// Removes item from set
        /// </summary>
        /// <param name="item">Item? that you want to remove</param>
        /// <returns>True if item successfully revoed from set, false if it not contains</returns>
        public bool Remove(T item)
        {
            try
            {
                var element = GetElementByValue(item);
                
                if (element == root)
                {
                    if (element.IsLeaf())
                    {
                        root = null;
                        Count--;
                        return true;
                    }
                    if (element.LeftChild != null && element.RightChild == null)
                    {
                        root = element.LeftChild;
                        Count--;
                        return true;
                    }
                    if (element.RightChild != null && element.LeftChild == null)
                    {
                        root = element.RightChild;
                        root.Parent = null;
                        Count--;
                        return true;
                    }
                }

                if (element.IsLeaf())
                {
                    SetNewChid(element.Parent, element, null);
                    Count--;
                    return true;
                }
                if (element.LeftChild != null && element.RightChild == null)
                {
                    SetNewChid(element.Parent, element, element.LeftChild);
                    Count--;
                    return true;
                }
                if (element.RightChild != null && element.LeftChild == null)
                {
                    SetNewChid(element.Parent, element, element.RightChild);
                    Count--;
                    return true;
                }

                var buffer = GetNewChild(element).Value;
                Remove(buffer);
                element.Value = buffer;
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks is this equal to other collection
        /// </summary>
        /// <param name="other">Input collection</param>
        /// <returns>True if other has same items than other</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);
            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return Count == helpSet.Count;
        }

        /// <summary>
        /// Removes all common items and adds all not contained items from other to this
        /// </summary>
        /// <param name="other">Other collection</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var helpSet = new MySet<T>(comparer);
            foreach (var item in other)
            {
                helpSet.Add(item);
            }

            foreach (var item in helpSet)
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Adds all items from other to this
        /// </summary>
        /// <param name="other">Other collection</param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                Add(item);
            }
        }

    }
}
