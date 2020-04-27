using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operators
{
    class Multiplication : IOperator
    {
        private Calculator calculator;

        public Multiplication(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public double Calculate() => double.Parse(calculator.Number1.Value) * double.Parse(calculator.Number2.Value);

        public string Print() => " * ";

    }
}
