using System;
using System.Collections.Generic;
using System.Text;

namespace PriotiryQueue
{
    /// <summary>
    /// Queue with priorities: First element - element with max key. Elements with same key in order of simple queue
    /// </summary>
    /// <typeparam name="T">Type of elements in queue</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Linear implimentation of queue by list
        /// </summary>
        private class QueueList
        {
            /// <summary>
            /// Elements in list
            /// </summary>
            private class ListElement
            {
                public ListElement(T value, int key, ListElement next)
                {
                    this.key = key;
                    this.value = value;
                    this.next = next;
                }

                public T value;
                public int key;

                public ListElement next;
            }

            private ListElement head;

            /// <summary>
            /// Adds element to tail of list
            /// </summary>
            /// <param name="value">Value of element</param>
            /// <param name="key">Priority key of element</param>
            public void Add(T value, int key)
            {
                if (head == null)
                {
                    head = new ListElement(value, key, null);
                    return;
                }

                var currentElement = head;
                while (currentElement.next != null)
                {
                    currentElement = currentElement.next;
                }

                currentElement.next = new ListElement(value, key, null);
            }

            /// <summary>
            /// Remove element with max key
            /// </summary>
            /// <returns>Value of element with max key</returns>
            public T ExtractMax()
            {
                if (head == null)
                {
                    throw new DequeueFromEmptyQueueException();
                }

                if (head.next == null)
                {
                    var output = head.value;
                    head = null;
                    return output;
                }

                int maxKey = head.key;
                var parentOfMaxElement = head;
                var currentElement = head;
                while (currentElement.next != null)
                {
                    if (maxKey < currentElement.next.key)
                    {
                        maxKey = currentElement.next.key;
                        parentOfMaxElement = currentElement;
                    }
                    currentElement = currentElement.next;
                }

                if (maxKey == head.key)
                {
                    var output = head.value;
                    head = head.next;
                    return output;
                }

                var result = parentOfMaxElement.next.value;
                parentOfMaxElement.next = parentOfMaxElement.next.next;
                return result;
            }

        }

        private QueueList list;

        public Queue()
        {
            list = new QueueList();
        }

        /// <summary>
        /// Adds new element to queue
        /// </summary>
        /// <param name="value">Value of new element</param>
        /// <param name="key">Priority key of new element</param>
        public void Enqueue(T value, int key) => list.Add(value, key);

        /// <summary>
        /// Extract element with max key from queue
        /// </summary>
        /// <exception cref="DequeueFromEmptyQueueException">Throws when queue is empty</exception>
        /// <returns>Value of element with max key</returns>
        public T Dequeue() => list.ExtractMax();

    }
}
