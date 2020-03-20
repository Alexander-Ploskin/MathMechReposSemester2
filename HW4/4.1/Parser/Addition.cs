using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Addition: Operator
    {
        public override int Calculate()
        {
            if (!CanCalculate())
            {
                throw new NotCorrectOrNotParsedExpressionException();
            }

            return leftChild.Calculate() + rightChild.Calculate();
        }

        public override void Print()
        {
            Console.WriteLine("+ ");
        }

    }
}
