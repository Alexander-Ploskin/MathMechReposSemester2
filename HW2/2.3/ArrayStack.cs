using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    class ArrayStack : IStack
    {
        private int[] arrayOfStackElements = new int[10000];

        private int head;

        public void Push(int value)
        {
            arrayOfStackElements[head] = value;
            head++;
        }

        public int Pop()
        {
            int result = arrayOfStackElements[head - 1];
            arrayOfStackElements[head] = 0;
            head--;
            return result;
        }

        public bool Empty() => head == 0;

    }
}
