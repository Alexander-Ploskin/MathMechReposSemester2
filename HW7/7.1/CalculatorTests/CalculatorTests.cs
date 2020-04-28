using NUnit.Framework;

namespace CalculatorTests
{
    using Calculator;
    using System;

    public class Tests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        private void EnterExpression(string expression)
        {
            foreach (var item in expression)
            {
                calculator.Add(item);
            }
        }

        [TestCase("1+1=", "2")]
        [TestCase("1.2-1=", "0.2")]
        [TestCase("10/5=", "2")]
        [TestCase("s3-3s=", "0")]
        [TestCase("4r+4.84r=", "4.2")]
        [TestCase("1+3=r", "2")]
        [TestCase("4-6=s", "2")]
        [TestCase("s16sr-2=", "2")]
        public void CorrectExpressionsTest(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [Test]
        public void DivideByZeroTest()
        {
            EnterExpression("1/0");
            Assert.Throws<DivideByZeroException>(() => calculator.Add('='));
        }

        [TestCase("1+2+3", "6")]
        [TestCase("1+2/3", "1")]
        [TestCase("1+2+s3", "0")]
        public void ManyOperatorsTest(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [Test]
        public void ClearTest()
        {
            EnterExpression("1+2.c");
            Assert.AreEqual("", calculator.Expression);
        }

    }
}