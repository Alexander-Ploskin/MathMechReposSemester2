using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class Operator: INodeOfParserTree
    {
        public Operator parent
        {
            get
            {
                if (parent == null)
                {
                    throw new NullParentException();
                }
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        protected INodeOfParserTree leftChild = null;
        protected INodeOfParserTree rightChild = null;

        protected bool Empty() => leftChild == null && rightChild == null;

        public abstract void Print();

        public abstract int Calculate();

        public Operator AddChildAndMove(Operator newChild)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                return newChild;
            }
            if (rightChild == null)
            {
                rightChild = newChild;
                return newChild;
            }
            throw new FullNodeException();
        }

        public void AddChildAndMove(Number newChild)
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

    }
}
