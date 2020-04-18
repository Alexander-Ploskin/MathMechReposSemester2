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
        /// <exception cref="NoCorrectExpressionException">Throws if parser hasn't tree</exception>
        /// <returns>Result of expression</returns>
        public int CalculateExpression()
        {
            if (!Allright())
            {
                throw new NoCorrectExpressionException();
            }

            return root.Calculate();
        }

        /// <summary>
        /// Prints expression
        /// </summary>
        /// <exception cref="NoCorrectExpressionException">Throws if parser hasn't tree</exception>
        public void PrintExpression()
        {
            if (!Allright())
            {
                throw new NoCorrectExpressionException();
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
