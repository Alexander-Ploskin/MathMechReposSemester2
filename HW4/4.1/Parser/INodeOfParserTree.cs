using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Interface of nodes of arithmetic expression tree
    /// </summary>
    interface INodeOfParserTree
    { 
        void Print();

        int Calculate();

        bool Full();
    }
}
