﻿using System;
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
        /// <exception cref="Exception">Throws if right subtee = 0</exception>
        /// <returns></returns>
        public override int Calculate()
        {
            if (!CanCalculate())
            {
                throw new Exception();
            }

            int valueOfRightChild = rightChild.Calculate();
            if (valueOfRightChild == 0)
            {
                throw new Exception("Division by null");
            }

            return leftChild.Calculate() / rightChild.Calculate();
        }

        /// <summary>
        /// Print /
        /// </summary>
        public override void Print()
        {
            Console.Write("/ ");
        }
    }
}
