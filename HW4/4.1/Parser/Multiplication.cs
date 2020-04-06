using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Multiplication operator in tree
    /// </summary>
    class Multiplication : Operator
    {
        /// <summary>
        /// Multiply left and right subtree
        /// </summary>
        /// <returns>Result of multiplication</returns>
        public override int Calculate() => leftChild.Calculate() * rightChild.Calculate();

        /// <summary>
        /// Print subtree
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("* ");
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
