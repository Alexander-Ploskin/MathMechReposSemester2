using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace ParserTests
{
    using Parser;

    public class ParserTests
    {
        private static IEnumerable<string> InvalidExpressions()
        {
            yield return "";
            yield return "    ";
            yield return "1 1";
            yield return "+";
            yield return "+ 1";
            yield return "1+";
        }

        [TestCaseSource("InvalidExpressions")]
        public void ParseInvalidExpressionsTest(string expression)
        {
            Assert.Throws<InvalidExpressionException>(() => Parser.ParseExpression(expression));
        }

        [TestCase("+ 2 2", 4)]
        [TestCase("- 1 3", -2)]
        [TestCase("* 2 2", 4)]
        [TestCase("/ 6 2", 3)]
        [TestCase("2", 2)]
        [TestCase("* + 2 2 + 2 2", 16)]
        [TestCase("* 2 + 2 2", 8)]
        [TestCase("* + 2 2 2", 8)]
        [TestCase("+ 11 22", 33)]
        public void CalculateTest(string expression, int expected)
        {
            Assert.AreEqual(expected, Parser.ParseExpression(expression).CalculateExpression());
        }

        [Test]
        public void DivideBeZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => Parser.ParseExpression("/ 10 - 5 5").CalculateExpression());
        }

    }
}