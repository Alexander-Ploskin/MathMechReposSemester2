using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Interface of node of parser of arithmetic tree
    /// </summary>
    abstract class INodeOfParserTree
    {
        public abstract void PrintValue();

        public abstract int Calculate();

        public INodeOfParserTree(Operator parent)
        {
            this.parent = parent;
        }

        protected Operator parent = null;

        abstract public void PrintValue();

        abstract public int Calculate();
    }
}
