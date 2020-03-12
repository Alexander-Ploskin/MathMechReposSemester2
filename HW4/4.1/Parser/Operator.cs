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
        protected INodeOfParserTree leftChild = null;
        protected INodeOfParserTree rightChild = null;

        protected bool Empty() => leftChild == null && rightChild == null;

        public abstract void Print();

        public abstract int Calculate();
    }
}
