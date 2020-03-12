using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ExpressionTree
    {
        private INodeOfParserTree root = null;

        private Operator currentParent = null;

        public INodeOfParserTree WhichOperator(char token)
        {
            if (token == '+')
            {
                return new Addition();
            }
            if (token == '-')
            {
                return new Subtraction();
            }
            if (token == '*')
            {
                return new Multiplication();
            }
            if (token == '/')
            {
                return new Division();
            }
            throw new Exception("Invalid token!");
        }

        public void Add(char value)
        {
            var newElement = WhichOperator(value);

            if (currentParent.leftChild == null)
            {
                
            }
        }

        public void Add(int value)
        {

        }
    }
}
