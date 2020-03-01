using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface IStack
    {
        void Push(int value);

        int Pop();

        bool Empty();

    }
}
