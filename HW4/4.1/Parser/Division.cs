using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Division: Operator
    {
        public override int Calculate()
        {
            if (!CanCalculate())
            {
                throw new Exception();
            }

            int valueOfRightChild = rightChild.Calculate();
            if (valueOfRightChild == 0)
            {
                throw new Exception();
            }

            return leftChild.Calculate() / rightChild.Calculate();
        }

        public override void Print()
        {
            Console.WriteLine("/ ");
        }
    }
}
