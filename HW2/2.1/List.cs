using System;

namespace Task1_2
{
    class List
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
            if (position < 0)
            {
                return null;
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

        public bool Remove(int position)
        {
            var parentOfRemovableElement = GetParentOfElementByPosition(position);
            if (parentOfRemovableElement == null || parentOfRemovableElement.next == null)
            {
                return false;
            }

            size--;

            parentOfRemovableElement.next = parentOfRemovableElement.next.next;

            return true;
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

        public bool Empty() => size == 0;
        public int Length() => size;

    }
}
