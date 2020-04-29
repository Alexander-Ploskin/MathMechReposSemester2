using NUnit.Framework;

namespace CalculatorTests
{
    using Calculator;
    using NUnit.Framework.Internal;
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

        [TestCase("11-1=", "10")]
        [TestCase("1+1=", "2")]
        [TestCase("10/5=", "2")]
        [TestCase("5*5=", "25")]
        public void CorrectSimpleExpressionsTest(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [TestCase("1,2-1=", "0,2")]
        [TestCase("1,1+1=", "2,1")]
        [TestCase("2,5/2=", "1,25")]
        [TestCase("2,5*2=", "5")]
        public void FirstNumberIsNotIntegerTest(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [TestCase("1-0,5=", "0,2")]
        [TestCase("1,1+1=", "2,1")]
        [TestCase("2,5/2=", "1,25")]
        [TestCase("2,5*2=", "5")]
        public void SecondNumberIsNotIntegerTest(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [TestCase("1+2+3", "6")]
        [TestCase("1+2/3", "1")]
        [TestCase("1+2-3", "0")]
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
            EnterExpression("123");
            Assert.AreEqual("123", calculator.Expression);
        }

        [Test]
        public void EmptyExpressionTest()
        {
            EnterExpression("+=");
            Assert.AreEqual("", calculator.Expression);
        }

        public void RandomTokensTest()
        {
            EnterExpression("5+F4%))=");
            Assert.AreEqual("9", calculator.Expression);
        }

        [TestCase("4r+5=", "7")]
        [TestCase("4+4r=", "6")]
        [TestCase("r4+5=", "9")]
        [TestCase("4+r5=", "9")]
        [TestCase("2+2=r", "2")]
        public void SqrtTests(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

        [TestCase("4s+5=", "-1")]
        [TestCase("4+4s=", "0")]
        [TestCase("s4+5=", "1")]
        [TestCase("4+s5=", "-1")]
        [TestCase("2+2=r", "-4")]
        [TestCase("44,s5+55,5s=", "101")]
        [TestCase("16rs", "-4")]
        public void ChangeSignTests(string expression, string expectedOutput)
        {
            EnterExpression(expression);
            Assert.AreEqual(expectedOutput, calculator.Expression);
        }

    }
}