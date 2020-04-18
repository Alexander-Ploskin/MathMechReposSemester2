using NUnit.Framework;
using System.Collections.Generic;

namespace CalculatorTests
{
    using Calculator;

    [TestFixture]
    public class StackTests
    {
        private static IEnumerable<IStack> TestCases()
        {
            yield return new ListStack();
            yield return new ArrayStack();
        }

        [TestCaseSource("TestCases")]
        public void PushTest(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.Empty());
        }

        [TestCaseSource("TestCases")]
        public void PopTest(IStack stack)
        {
            stack.Push(1);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestCaseSource("TestCases")]
        public void PopFromEmptyStackTest(IStack stack)
        {
            try
            {
                stack.Pop();
            }
            catch (PopFromEmptyStackException)
            {
                Assert.Pass();
            }
        }

        [TestCaseSource("TestCases")]
        public void PushOfTwoElementsTest(IStack stack)
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

    }
}
