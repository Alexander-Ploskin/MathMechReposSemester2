using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ArrayStack : IStack
    {
        private int[] arrayOfStackElements = new int[10];

        private int head;

        private void Resize()
        {
            var newArray = new int[arrayOfStackElements.Length * 2];
            arrayOfStackElements.CopyTo(newArray, 0);
            arrayOfStackElements = newArray;
        }

        public void Push(int value)
        {
            if (head == arrayOfStackElements.Length)
            {
                Resize();
            }

            arrayOfStackElements[head] = value;
            head++;
        }

        public int Pop()
        {
            if (Empty())
            {
                Console.WriteLine("Stack is empty!");
                return 0;
            }

            int result = arrayOfStackElements[head - 1];
            arrayOfStackElements[head] = 0;
            head--;
            return result;
        }

        public bool Empty() => head == 0;

    }
}
