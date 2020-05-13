using NUnit.Framework;

namespace CalculatorTests
{
    using Calculator;
    
    public class CalculatorTests
    {
        [SetUp]
        public void Initialize()
        {
            stack = new ListStack();
        }

        [Test]
        public void AdditionOfTwoBigNumbersTest()
        {
            Assert.AreEqual((100010, true), Calculator.Calculate("50005 50005 +", stack));
        }

        [Test]
        public void AdditionOfPositiveAndNegativeNumbersTest()
        {
            Assert.AreEqual((0, true), Calculator.Calculate("-50005 50005 +", stack));
        }

        [Test]
        public void AdditionWithNullTest()
        {
            Assert.AreEqual((50005, true), Calculator.Calculate("50005 0 +", stack));
        }

        [Test]
        public void AdditionOfTwoNullsTest()
        {
            Assert.AreEqual((0, true), Calculator.Calculate("0 0 +", stack));
        }

        [Test]
        public void AdditionOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual((-20, true), Calculator.Calculate("-10 -10 +", stack));
        }

        [Test]
        public void ALotOfAdditionsTest()
        {
            Assert.AreEqual((40, true), Calculator.Calculate("10 5 + 10 5 + + 10 +", stack));
        }

        [Test]
        public void AdditionAndMultiplicationTest()
        {
            Assert.AreEqual((30, true), Calculator.Calculate("10 0 + 1 2 + *", stack));
        }

        [Test]
        public void DivisionByNullTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("100 0 /", stack));
        }

        [Test]
        public void NotIntegerNumbersTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("1.2 1.2 +", stack));
        }

        [Test]
        public void UnwantedSymbolsTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("a b +", stack));
        }

        [Test]
        public void DivisionByNullInCaseOfAdditionTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("5 2 -2 + /", stack));
        }

        [Test]
        public void MultiplicationOfTwoNegativeNumbersTest()
        {
            Assert.AreEqual((10, true), Calculator.Calculate("-2 -5 *", stack));
        }

        [Test]
        public void EmptyStringTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("     ", stack));
        }

        [Test]
        public void InfixExpressionTest()
        {
            Assert.AreEqual((0, false), Calculator.Calculate("2 + 2", stack));
        }
        
        [Test]
        public void JustNumberTest()
        {
            Assert.AreEqual((101, true), Calculator.Calculate("101", stack));
        }

        private ListStack stack;
    }
}