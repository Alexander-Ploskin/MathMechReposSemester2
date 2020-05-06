using System;

namespace Parser
{
    /// <summary>
    /// Implements number nodes in tree
    /// </summary>
    class Number : INodeOfExpressionTree
    {
        private int value = 0;

        public Number(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Numbers always full
        /// </summary>
        public bool Full() => true;

        /// <summary>
        /// Print value
        /// </summary>
        public void Print()
        {
            Console.Write($"{value} ");
        }

        /// <summary>
        /// Calculate our subtree
        /// </summary>
        /// <returns>Value</returns>
        public int Calculate() => value;

    }
}
