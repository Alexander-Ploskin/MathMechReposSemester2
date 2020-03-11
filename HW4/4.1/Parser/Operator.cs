using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    abstract class Operator: INodeOfParserTree
    {
        public INodeOfParserTree rightChild = null;
        public INodeOfParserTree leftChild = null;

        public abstract void PrintValue();

        public abstract int Calculate();

        public bool Empty() => rightChild == null || leftChild == null;

    }
}
