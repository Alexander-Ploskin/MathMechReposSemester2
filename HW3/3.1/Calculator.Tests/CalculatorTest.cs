using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new ListStack();
        }

        [TestMethod]
        public void AdditionOfTwoBigNumbersTest()
        {
            Assert.AreEqual(Calculator.Calculate("50005 50005 +", stack), (100010, true));
        }

        [TestMethod]
        public void AdditionOfPositiveAndNegativeNumbersTest()
        {
            Assert.AreEqual(Calculator.Calculate("-50005 50005 +", stack), (0, true));
        }

        [TestMethod]
        public void AdditionWithNullTest()
        {
            Assert.AreEqual(Calculator.Calculate("50005 0 +", stack), (50005, true));
        }

        [TestMethod]
        public void AdditionOfTwoNullsTest()
        {
            Assert.AreEqual(Calculator.Calculate("0 0 +", stack), (0, true));
        }

        [TestMethod]
        public void AdditionOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual(Calculator.Calculate("-10 -10 +", stack), (-20, true));
        }

        [TestMethod]
        public void ALotOfAdditionsTest()
        {
            Assert.AreEqual(Calculator.Calculate("10 5 + 10 5 + + 10 +", stack), (40, true));
        }

        [TestMethod]
        public void AdditionAndMultiplicationTest()
        {
            Assert.AreEqual(Calculator.Calculate("10 0 + 1 2 + *", stack), (30, true));
        }

        [TestMethod]
        public void DivisionByNullTest()
        {
            Assert.AreEqual(Calculator.Calculate("100 0 /", stack), (0, false));
        }

        [TestMethod]
        public void NotIntegerNumbersTest()
        {
            Assert.AreEqual(Calculator.Calculate("1.2 1.2 +", stack), (0, false));
        }

        [TestMethod]
        public void UnwantedSymbolsTest()
        {
            Assert.AreEqual(Calculator.Calculate("a b +", stack), (0, false));
        }

        [TestMethod]
        public void DivisionByNullInCaseOfAdditionTest()
        {
            Assert.AreEqual(Calculator.Calculate("5 2 -2 + /", stack), (0, false));
        }

        [TestMethod]
        public void MultiplicationOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual(Calculator.Calculate("-2 -5 *", stack), (10, true));
        }

        [TestMethod]
        public void EmptyStringTest()
        {
            Assert.AreEqual(Calculator.Calculate("     ", stack), (0, false));
        }

        [TestMethod]
        public void InfixExpressionTest()
        {
            Assert.AreEqual(Calculator.Calculate("2 + 2", stack), (0, false));
        }

        [TestMethod]
        public void JustNumberTest()
        {
            Assert.AreEqual(Calculator.Calculate("101", stack), (101, true));
        }

        private ListStack stack;
    }
}
