using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Calculator
{
    class Number
    {
        public string Value { get; set; }


        private int sign = 1;

        public void ChangeSign() => sign *= -1;

        public void CalculateSqrt() => Value = Math.Sqrt(sign * double.Parse(Value)).ToString();

        public void Clear()
        {
            Value = " ";
        }

        public void RemoveLastSymbol() => Value = Value.Remove(Value.Length - 1);

    }
}
