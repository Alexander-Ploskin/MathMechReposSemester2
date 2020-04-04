using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Implements number nodes in tree
    /// </summary>
    class Number: INodeOfParserTree
    {
        private int value = 0;

        public Number(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Print value
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{value} ");
        }

        /// <summary>
        /// Calculate our subtree
        /// </summary>
        /// <returns>Value</returns>
        public int Calculate()
        {
            return value;
        }
    }
}
