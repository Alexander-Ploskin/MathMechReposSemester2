using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    class NullOperator : IOperator
    {

        public double Calculate() => throw new ApplicationException();

        public string Print() => "";

    }
}
