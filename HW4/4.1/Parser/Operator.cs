using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class Operator: INodeOfParserTree
    {
        protected Operator parent = null;
        protected INodeOfParserTree rightChild = null;
        protected INodeOfParserTree leftChild = null;

        public bool CanAdd() => rightChild == null || leftChild == null;

        public INodeOfParserTree AddChildAndMove(INodeOfParserTree newChild)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                return leftChild;
            }
            if (rightChild == null)
            {
                rightChild = newChild;
                return rightChild;
            }
            throw new Exception();
        }

    }
}
