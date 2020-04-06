using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserTests
{
    using Parser;

    [TestClass]
    public class ParserTests
    {
        private Parser parser;

        [TestInitialize]
        public void Initialize()
        {
            parser = new Parser();
        }

        [TestMethod]
        public void ParseEmptyStringTest()
        {
            Assert.ThrowsException<InvalidExpressionException>(() => parser.ParseExpression(""));
        }

        [TestMethod]
        public void ParseWhiteSpaceTest()
        {
            Assert.ThrowsException<InvalidExpressionException>(() => parser.ParseExpression("    "));
        }

        [TestMethod]
        public void ParseExpressionOfTwoNumbersTest()
        {
            Assert.ThrowsException<InvalidExpressionException>(() => parser.ParseExpression("1 1"));
        }

        [TestMethod]
        public void ParseExpressionOfOperationWithoutOperandsTest()
        {
            Assert.ThrowsException<InvalidExpressionException>(() => parser.ParseExpression("+"));
        }

        [TestMethod]
        public void ParseExpressionOfOperatorWithOnlyOneOperandTest()
        {
            Assert.ThrowsException<InvalidExpressionException>(() => parser.ParseExpression("+ 1"));
        }

        [TestMethod]
        public void SimpleAdditionTest()
        {
            parser.ParseExpression("+ 2 2");
            Assert.AreEqual(4, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void SimpleSubtractionTest()
        {
            parser.ParseExpression("- 1 3");
            Assert.AreEqual(-2, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void SimpleMultiplicationTest()
        {
            parser.ParseExpression("* 2 2");
            Assert.AreEqual(4, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void SimpleDivisionTest()
        {
            parser.ParseExpression("/ 6 2");
            Assert.AreEqual(3, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void ParseNumberStringTest()
        {
            parser.ParseExpression("2");
            Assert.AreEqual(2, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void ParseBigExpressionTest()
        {
            parser.ParseExpression("* + 2 2 + 2 2");
            Assert.AreEqual(16, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void ParseBigExpressionWithNumberFirst()
        {
            parser.ParseExpression("* 2 + 2 2");
            Assert.AreEqual(8, parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void ParseBigExpressionWithNumberSecond()
        {
            parser.ParseExpression("* + 2 2 2");
            Assert.AreEqual(8, parser.CalculateParsedExpression());
        }

        [TestMethod] 
        public void DivideBeZeroTest()
        {
            parser.ParseExpression("/ 10 - 5 5");
            Assert.ThrowsException<DivideByZeroException>(() => parser.CalculateParsedExpression());
        }

        [TestMethod]
        public void BigNumberTest()
        {
            parser.ParseExpression("+ 11 22");
            Assert.AreEqual(33, parser.CalculateParsedExpression());
        }

    }
}
