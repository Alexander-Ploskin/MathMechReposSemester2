using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ListStack: IStack
    {
        private class StackElement
        {
            public StackElement(int value, StackElement next)
            {
                this.value = value;
                this.next = next;
            }

            public int value;
            public StackElement next;
        }

        private StackElement head;

        public void Push(int value)
        {
            head = new StackElement(value, head);
        }

        public int Pop()
        {
            if (Empty())
            {
                Console.WriteLine("Stack is Empty!");
                return 0;
            }
            int result = head.value;
            head = head.next;
            return result;
        }

        public bool Empty() => head == null;

    }
}
