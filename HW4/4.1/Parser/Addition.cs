using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Addition operator in tree
    /// </summary>
    class Addition: Operator
    {
        /// <summary>
        /// Addition of right and left subtree
        /// </summary>
        /// <returns>Result of addition</returns>
        public override int Calculate()
        {
            if (!CanCalculate())
            {
                throw new NotCorrectOrNotParsedExpressionException();
            }

            return leftChild.Calculate() + rightChild.Calculate();
        }

        /// <summary>
        /// Print subtree
        /// </summary>
        public override void Print()
        {
            Console.Write("+ ");
            if (leftChild != null)
            {
                leftChild.Print();
            }
            if (rightChild != null)
            {
                rightChild.Print();
            }
        }

    }
}
