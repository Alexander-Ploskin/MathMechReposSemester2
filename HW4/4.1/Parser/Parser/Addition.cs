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
        public override int Calculate() => leftChild.Calculate() + rightChild.Calculate();

        /// <summary>
        /// Prints +
        /// </summary>
        public override void Print()
        {
            Console.Write("+ ");
            base.Print();
        }

    }
}
