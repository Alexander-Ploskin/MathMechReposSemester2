using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Number: INodeOfParserTree
    {
        private int value = 0;

        public void Print()
        {
            Console.WriteLine($"{value} ");
        }

        public int Calculate()
        {
            return value;
        }
    }
}
