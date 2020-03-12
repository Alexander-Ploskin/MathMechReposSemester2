using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Division: Operator
    {
        public override void PrintValue()
        {
            Console.Write("/ ");
        }

        public override int Calculate()
        {
            if (CanAdd())
            {
                throw new Exception();
            }

            if (rightChild.Calculate() == 0)
            {
                throw new Exception();
            }

            return leftChild.Calculate() / rightChild.Calculate();
        }
    }
}
