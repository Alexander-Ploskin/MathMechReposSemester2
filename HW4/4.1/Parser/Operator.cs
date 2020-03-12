using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class Operator: INodeOfParserTree
    {
        private Operator parent = null;
        private INodeOfParserTree leftChild = null;
        private INodeOfParserTree rightChild = null;

        public Operator(Operator parent)
        {
            this.parent = parent;
        }

        public abstract void Print();

        public abstract int Calculate();
    }
}
