using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class Operator: INodeOfParserTree
    { 
        protected INodeOfParserTree leftChild = null;
        protected INodeOfParserTree rightChild = null;

        protected bool Empty() => leftChild == null && rightChild == null;

        public abstract void Print();

        public abstract int Calculate();

        private void AddNewChild(Number newChild)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                return;
            }
            if (rightChild == null)
            {
                rightChild = newChild;
                return;
            }

            throw new FullNodeException();
        }

        private void AddNewChild(Operator newChild, ref Operator currentParent)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                currentParent = leftChild;
                return;
            }
        }
    }
}
