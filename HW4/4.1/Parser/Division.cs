using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Division operator in tree
    /// </summary>
    class Division: Operator
    {
        /// <summary>
        /// Divide left subtree by right subtree
        /// </summary>
        /// <returns></returns>
        public override int Calculate() => leftChild.Calculate() / rightChild.Calculate();

        /// <summary>
        /// Print subtree
        /// </summary>
        public override void Print()
        {
            Console.Write("/ ");
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
