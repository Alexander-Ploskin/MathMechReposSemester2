﻿using System;

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
        /// Prints *
        /// </summary>
        public override void Print()
        {
            Console.Write("* ");
            base.Print();
        }

    }
}