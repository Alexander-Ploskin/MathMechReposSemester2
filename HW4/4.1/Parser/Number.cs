using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Number: INodeOfParserTree
    {
        public Number(int number)
        {
            this.value = number;
        }

        private int value = 0;
        public override void PrintValue()
        {
            Console.Write($"{value} ");
        }

        public override int Calculate() => value;
    }
}
