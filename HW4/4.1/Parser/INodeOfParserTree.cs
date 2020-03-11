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
    interface INodeOfParserTree
    {
        void PrintValue();

        int Calculate();
    }
}
