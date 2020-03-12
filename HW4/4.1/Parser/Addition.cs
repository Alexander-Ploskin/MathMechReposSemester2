using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Addition: Operator
    {

        public override void PrintValue()
        {
            Console.Write("+ ");
        }

        public override int Calculate()
        {
            if (CanAdd())
            {
                throw new Exception();
            }

            return leftChild.Calculate() + rightChild.Calculate();
        }
    }
}
