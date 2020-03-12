using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Subtraction: Operator
    {
        public override int Calculate()
        {
            if (Empty())
            {
                throw new Exception();
            }

            return leftChild.Calculate() - rightChild.Calculate();
        }

        public override void Print()
        {
            Console.WriteLine("- ");
        }
    }
}
