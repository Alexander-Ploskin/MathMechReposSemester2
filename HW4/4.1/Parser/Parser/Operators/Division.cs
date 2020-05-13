using System;

namespace Parser
{
    /// <summary>
    /// Division operator in tree
    /// </summary>
    class Division : Operator
    {
        /// <summary>
        /// Divide left subtree by right subtree
        /// </summary>
        /// <returns></returns>
        public override int Calculate() => leftChild.Calculate() / rightChild.Calculate();

        /// <summary>
        /// Prints /
        /// </summary>
        public override void Print()
        {
            Console.Write("/ ");
            base.Print();
        }

    }
}
