using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Calculator
{
    public class Number
    {
        public string Value { get; set; } = "";

        public void ChangeSign()
        {
            if (Value.Length == 0)
            {
                Value = "-";
                return;
            }
            if (Value[0] == '-')
            {
                Value = Value.Remove(0, 1);
                return;
            }

            Value = "-" + Value;
        }

        public void CalculateSqrt()
        {
            double buffer = Math.Sqrt(double.Parse(Value));
            if (double.IsNaN(buffer))
            {
                throw new SqrtByNegativeNumberException();
            }
            Value = buffer.ToString();
        }

        public void Clear()
        {
            Value = "";
        }

        public void RemoveLastSymbol() => Value = Value.Remove(Value.Length - 1);

    }
}
