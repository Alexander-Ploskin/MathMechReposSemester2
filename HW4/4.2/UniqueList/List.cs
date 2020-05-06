using System;

namespace UniqueList
{
    /// <summary>
    /// List with removing and addition by position
    /// </summary>
    public class List
    {
        /// <summary>
        /// Element of list
        /// </summary>
        private class ListElement
        {
            public ListElement(int value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public int value;
            public ListElement next;
        }

        private ListElement head;

        private int size;

        /// <summary>
        /// Add new element to desired position
        /// </summary>
        /// <param name="value">Value, you wanna to add</param>
        /// <exception cref="InvalidPositionException">Throws in case of invalid position</exception>
        /// <param name="position">Position in list for new element</param>
        public virtual void Add(int value, int position)
        {
            if (position < 0)
            {
                throw new InvalidPositionException();
            }

            if (position == 0)
            {
                head = new ListElement(value, head);
                size++;
                return;
            }

            var currentElement = head;
            for (int i = 0; i < position - 1; ++i)
            {
                if (currentElement == null)
                {
                    throw new InvalidPositionException();
                }
                currentElement = currentElement.next;
            }
            currentElement.next = new ListElement(value, currentElement.next);
            size++;
        }

        /// <summary>
        /// Gets reference to parent of desired element
        /// </summary>
        /// <param name="position">Position of desired element</param>
        /// <returns>Parent</returns>
        private ListElement GetParentOfElementByPosition(int position)
        {
            if (position <= 0)
            {
                throw new IndexOutOfRangeException();
            }

            var currentElement = head;

            for (int i = 0; i < position - 1; ++i)
            {
                if (currentElement == null || currentElement.next == null)
                {
                    throw new IndexOutOfRangeException();
                }

                currentElement = currentElement.next;
            }

            return currentElement;
        }

        private void RemoveNext(ListElement parent)
        {
            parent.next = parent.next.next;
            size--;
        }

        /// <summary>
        /// Remove element by position
        /// </summary>
        /// <exception cref="RemoveByNotExistPositionException">Throws in case of invalid position</exception>
        /// <param name="position">Desired position</param>
        public void RemoveByPosition(int position)
        {
            if (Empty())
            {
                throw new RemoveFromEmptyListException();
            }

            if (position == 0)
            {
                head = head.next;
                size--;
                return;
            }
            try
            {
                var parentOfRemovableElement = GetParentOfElementByPosition(position);
                RemoveNext(parentOfRemovableElement);
            }
            catch (IndexOutOfRangeException)
            {
                throw new RemoveByNotExistPositionException();
            }
        }

        /// <summary>
        /// Remove concrete value in list
        /// </summary>
        /// <exception cref="RemoveFromEmptyListException">Throws if list is empty</exception>
        /// <exception cref="RemoveOfNotContainedElementException">Throws if value doesn't contain in list</exception>
        /// <param name="value">Value, you wanna to remove</param>
        public void RemoveByValue(int value)
        {
            if (Empty())
            {
                throw new RemoveFromEmptyListException();
            }

            if (head.value == value)
            {
                head = head.next;
                size--;
                return;
            }

            var currentElement = head;
            while (currentElement.next != null)
            {
                if (currentElement.next.value == value)
                {
                    RemoveNext(currentElement);
                    return;
                }
            }

            throw new RemoveOfNotContainedElementException();
        }

        private ListElement GetNext(ListElement currentElement) => currentElement.next;

        /// <summary>
        /// Print all values in list in order
        /// </summary>
        public void Print()
        {
            var currentElement = head;

            while (currentElement != null)
            {
                Console.Write("{0} ", currentElement.value);
                currentElement = GetNext(currentElement);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Gets value of element on desired position
        /// </summary>
        /// <exception cref="InvalidPositionException">Throws in case of invalid position</exception>
        /// <param name="position">Position in list</param>
        /// <returns>Value</returns>
        public int GetValueOfElementByPosition(int position)
        {
            if (position < 0)
            {
                throw new InvalidPositionException();
            }

            if (position >= size)
            {
                throw new InvalidPositionException();
            }

            if (position == 0)
            {
                return head.value;
            }

            return GetParentOfElementByPosition(position).next.value;
        }

        /// <summary>
        /// Sets value to element on desired position
        /// </summary>
        /// <exception cref="InvalidPositionException">Throws in case of invalid position</exception>
        /// <param name="position">Position in list</param>
        /// <param name="newValue">new value</param>
        public virtual void SetValueOnPosition(int position, int newValue)
        {
            if (position < 0)
            {
                throw new InvalidPositionException();
            }

            if (position >= size)
            {
                throw new InvalidPositionException();
            }

            if (position == 0)
            {
                head.value = newValue;
                return;
            }

            GetParentOfElementByPosition(position).next.value = newValue;
        }

        public bool Empty() => size == 0;

        public int Length() => size;

        /// <summary>
        /// Checks availibility of value in list
        /// </summary>
        /// <param name="value">Checking value</param>
        /// <returns>True if contains</returns>
        public bool Contains(int value)
        {
            var currentElement = head;

            while (currentElement != null)
            {
                if (currentElement.value == value)
                {
                    return true;
                }
                currentElement = currentElement.next;
            }

            return false;
        }

    }
}
