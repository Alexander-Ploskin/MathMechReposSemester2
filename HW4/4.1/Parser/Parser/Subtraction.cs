using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Subtraction operators in tree
    /// </summary>
    class Subtraction: Operator
    {
        /// <summary>
        /// Subtracts right subtree by left
        /// </summary>
        /// <returns>Result of subtraction</returns>
        public override int Calculate() => leftChild.Calculate() - rightChild.Calculate();

        /// <summary>
        /// Prints - 
        /// </summary>
        public override void Print()
        {
            Console.Write("- ");
            base.Print();

        }

    }
}
