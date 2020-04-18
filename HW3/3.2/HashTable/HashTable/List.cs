using System;

namespace HashTable
{
    /// <summary>
    /// Class list
    /// Contains strings 
    /// All operations has linear asymptotics
    /// </summary>
    public class List 
    {
        /// <summary>
        /// Element of list
        /// Has reference to next element 
        /// </summary>
        private class ListElement
        {
            public ListElement(string value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public string value;
            public ListElement next;
        }

        private ListElement head;

        private int size;

        /// <summary>
        /// Adds new element to list
        /// </summary>
        /// <param name="value">String that you wanna to add</param>
        public void Add(string value)
        {
            head = new ListElement(value, head);
            size++;
        }

        /// <summary>
        /// Returns parent of element on position
        /// </summary>
        /// <param name="position">Position of element that parent you wanna to get</param>
        /// <returns>Element that have reference to element on position</returns>
        /// <remarks>If such element doesn't exist returns null</remarks>
        private ListElement GetParentOfElementByPosition(int position)
        {
            if (position == 0)
            {
                return null;
            }
            
            if (position == 1)
            {
                return head;
            }

            var currentElement = head;

            for (int i = 0; i < position - 2; ++i)
            {
                if (currentElement == null)
                {
                    return null;
                }

                currentElement = currentElement.next;
            }

            return currentElement;
        }

        /// <summary>
        /// Returns parent of element that have users string
        /// </summary>
        /// <param name="value">String, that you wanna to get parent</param>
        /// <returns>element that have reference to element with this value</returns>
        /// <remarks>If such element doesn't exist, returns null</remarks>
        private ListElement GetParentOfElementByValue(string value)
        {
            if (head.value == value)
            {
                return null;
            }

            var currentElement = head;

            while (currentElement != null && currentElement.next != null)
            {
                if (currentElement.next.value == value)
                {
                    return currentElement;
                }
                currentElement = currentElement.next;
            }

            return null;
        }

        /// <summary>
        /// Removes element with users string
        /// </summary>
        /// <param name="value">String, whoose element you wanna to remove</param>
        public void RemoveByValue(string value)
        {
            if (head == null)
            {
                return;
            }

            if (head.value == value)
            {
                head = head.next;
                size--;
                return;
            }

            var parentOfElement = GetParentOfElementByValue(value);

            if (parentOfElement == null)
            {
                return;
            }

            parentOfElement.next = parentOfElement.next.next;
            size--;
        }

        /// <summary>
        /// Prints all strings of the list
        /// </summary>
        public void Print()
        {
            var currentElement = head;

            while (currentElement != null)
            {
                Console.Write($"{currentElement.value}");
                currentElement = currentElement.next;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Returns value of the head and removes head
        /// </summary>
        /// <returns>String of head</returns>
        public string Pop()
        {
            if (Empty())
            {
                return "";
            }

            string buffer = head.value;
            head = head.next;
            size--;
            return buffer;
        }

        /// <summary>
        /// Checks for availability of string in list
        /// </summary>
        /// <param name="value">String that you wanna to check</param>
        /// <returns>True if string contains in the list, else false</returns>
        public bool Contains(string value)
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

        /// <summary>
        /// Checks is list empty
        /// </summary>
        /// <returns>True if list is empty, else false</returns>
        public bool Empty() => size == 0;

        /// <summary>
        /// Returns size of list
        /// </summary>
        /// <returns>Size of list</returns>
        public int Length() => size;

    }
}
