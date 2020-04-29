using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    using Calculator;
    using Calculator.Operators;
    using System;

    class OperatorsTests
    {

        private static object[] CalculateCases =
        {
            new object[] { new Addition(), 7.5 },
            new object[] { new Division(), 2 },
            new object[] { new Multiplication(), 12.5 },
            new object[] { new Subtraction(), 2.5 }
        };

        [TestCaseSource("CalculateCases")]
        public void CalculateTest(IOperator testOperator, double expextedResult)
            => Assert.AreEqual(expextedResult, testOperator.Calculate(5, 2.5));

        [Test]
        public void DivideByZeroTest() 
            => Assert.Throws<DivideByZeroException>(() => new Division().Calculate(5, 0));

    }
}
