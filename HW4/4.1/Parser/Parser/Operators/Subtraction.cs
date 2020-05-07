﻿using System;

namespace Parser
{
    /// <summary>
    /// Subtraction operators in tree
    /// </summary>
    class Subtraction : Operator
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