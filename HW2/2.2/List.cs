using System;

namespace Task2_2
{
    class List 
    {
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

        public void Add(string value)
        {
            head = new ListElement(value, head);
            size++;
        }

        private ListElement GetParentOfElementByPosition(int position)
        {
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
        public void RemoveByPosition(int position)
        {
            var parentOfRemovableElement = GetParentOfElementByPosition(position);
            if (parentOfRemovableElement == null || parentOfRemovableElement.next == null)
            {
                return;
            }

            size--;

            parentOfRemovableElement.next = parentOfRemovableElement.next.next;
        }

        private ListElement GetParentOfElementByValue(string value)
        {
            var currentElement = head;

            while (currentElement != null && currentElement.next != null)
            {
                if (currentElement.next.value == value)
                {
                    return currentElement;
                }
                currentElement = GetNext(currentElement);
            }

            return null;
        }

        public void RemoveByValue(string value)
        {
            if (head.value == value)
            {
                head = head.next;
            }

            var parentOfElement = GetParentOfElementByValue(value);

            if (parentOfElement == null)
            {
                return;
            }

            parentOfElement.next = parentOfElement.next.next;
        }

        private ListElement GetNext(ListElement currentElement) => currentElement.next;

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

        public string Pop()
        {
            if (Empty())
            {
                return "";
            }

            string buffer = head.value;
            head = head.next;
            return buffer;
        }

        public bool Contains(string value)
        {
            var currentElement = head;

            while (currentElement != null)
            {
                if (currentElement.value == value)
                {
                    return true;
                }
                currentElement = GetNext(currentElement);
            }

            return false;
        }

        public bool Empty() => size == 0;

        public int Length() => size;

    }
}
