using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    using Calculator;
    using Calculator.Operators;
    using System;

    class OperatorsTests
    {
        private static IEnumerable<(IOperator, double)> TestCases()
        {
            yield return (new Addition(), 7.5);
            yield return (new Division(), 2);
            yield return (new Multiplication(), 12.5);
            yield return (new Subtraction(), 2.5);
        }

        [TestCaseSource("TestCases")]
        public void CalculateTest(IOperator testOperator, double expextedResult)
            => Assert.AreEqual(expextedResult, testOperator.Calculate(5, 2.5));

        [Test]
        public void DivideByZeroTest() 
            => Assert.Throws<DivideByZeroException>(() => new Division().Calculate(5, 0));

    }
}
