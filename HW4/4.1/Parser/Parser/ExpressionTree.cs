using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    /// <summary>
    /// Arithmetic expression tree
    /// </summary>
    public class ExpressionTree
    {
        public INodeOfExpressionTree root { get; set; }

        /// <summary>
        /// Calculeate expression by built tree
        /// </summary>
        /// <exception cref="NotCorrectExpressionException">Throws if parser hasn't tree</exception>
        /// <returns>Result of expression</returns>
        public int CalculateExpression()
        {
            if (!Allright())
            {
                throw new NotCorrectExpressionException();
            }

            return root.Calculate();
        }

        /// <summary>
        /// Prints expression
        /// </summary>
        /// <exception cref="NotCorrectExpressionException">Throws if parser hasn't tree</exception>
        public void PrintExpression()
        {
            if (!Allright())
            {
                throw new NotCorrectExpressionException();
            }

            root.Print();
        }

        /// <summary>
        /// Checks availibility of invalid operators in tree
        /// </summary>
        /// <returns>Availibility of invalid operators</returns>
        public bool Allright()
        {
            if (root == null)
            {
                return false;
            }

            return root.Full();

        }

    }
}
