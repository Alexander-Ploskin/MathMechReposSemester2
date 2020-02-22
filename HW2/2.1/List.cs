using System;

namespace Task1_2
{
    class List : IList
    {
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

        public void Add(int value)
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
        public void Remove(int position)
        {
            var parentOfRemovableElement = GetParentOfElementByPosition(position);
            if (parentOfRemovableElement == null || parentOfRemovableElement.next == null)
            {
                return;
            }

            size--;

            parentOfRemovableElement.next = parentOfRemovableElement.next.next;
        }

        private ListElement getNext(ListElement currentElement)
        {
            return currentElement.next;
        }

        public void Print()
        {
            var currentElement = head;

            while (currentElement != null)
            {
                Console.Write("{0} ", currentElement.value);
                currentElement = getNext(currentElement);
            }

            Console.WriteLine();
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int Length()
        {
            return size;
        }
    }
}
