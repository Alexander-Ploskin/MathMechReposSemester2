using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Calculator
{
    /// <summary>
    /// Class of numbers in calculator
    /// </summary>
    public class Number
    {
        /// <summary>
        /// This number in string form
        /// </summary>
        public string Value { get; set; } = "";

        /// <summary>
        /// Changes sign og this
        /// </summary>
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

        /// <summary>
        /// Extracts square root from this
        /// </summary>
        public void CalculateSqrt()
        {
            double buffer = Math.Sqrt(double.Parse(Value));
            if (double.IsNaN(buffer))
            {
                throw new SqrtByNegativeNumberException();
            }
            Value = buffer.ToString();
        }

        /// <summary>
        /// Erase value
        /// </summary>
        public void Clear()
        {
            Value = "";
        }

        /// <summary>
        /// Removes last symbol
        /// </summary>
        public void RemoveLastSymbol()
        {
            try
            {
                Value = Value.Remove(Value.Length - 1);
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

    }
}
