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
            Assert.AreEqual((100010, true), Calculator.Calculate("50005 50005 +", stack));
        }

        [TestMethod]
        public void AdditionOfPositiveAndNegativeNumbersTest()
        {
            Assert.AreEqual((0, true), Calculator.Calculate("-50005 50005 +", stack));
        }

        [TestMethod]
        public void AdditionWithNullTest()
        {
            Assert.AreEqual((50005, true), Calculator.Calculate("50005 0 +", stack));
        }

        [TestMethod]
        public void AdditionOfTwoNullsTest()
        {
            Assert.AreEqual((0, true), Calculator.Calculate("0 0 +", stack));
        }

        [TestMethod]
        public void AdditionOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual((-20, true), Calculator.Calculate("-10 -10 +", stack));
        }

        [TestMethod]
        public void ALotOfAdditionsTest()
        {
            Assert.AreEqual((40, true), Calculator.Calculate("10 5 + 10 5 + + 10 +", stack));
        }

        [TestMethod]
        public void AdditionAndMultiplicationTest()
        {
            Assert.AreEqual((30, true), Calculator.Calculate("10 0 + 1 2 + *", stack));
        }

        [TestMethod]
        public void DivisionByNullTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("100 0 /", stack));
        }

        [TestMethod]
        public void NotIntegerNumbersTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("1.2 1.2 +", stack));
        }

        [TestMethod]
        public void UnwantedSymbolsTest()
        {
            Assert.AreEqual((0, false), Сalculator.Calculate("a b +", stack));
        }

        [TestMethod]
        public void DivisionByNullInCaseOfAdditionTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("5 2 -2 + /", stack));
        }

        [TestMethod]
        public void MultiplicationOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual((10, true), Calculator.Calculate("-2 -5 *", stack));
        }

        [TestMethod]
        public void EmptyStringTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("     ", stack));
        }

        [TestMethod]
        public void InfixExpressionTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("2 + 2", stack));
        }

        [TestMethod]
        public void JustNumberTest()
        {
            Assert.AreEqual((101, true), Calculator.Calculate("101", stack));
        }

        private ListStack stack;
    }
}
