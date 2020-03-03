using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class ArrayStackTest
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new ArrayStack();
        }

        [TestMethod]
        public void PushTest()
        {
            stack.Push(1);
            Assert.IsFalse(stack.Empty());
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(1);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        public void PopFromEmptyStackTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PushOfTwoElementsTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]

        public void ResizeTest()
        {
            for (int i = 0; i < 11; ++i)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 10; ++i)
            {
                stack.Pop();
            }

            Assert.AreEqual(stack.Pop(), 0);
        }

        private ArrayStack stack;
    }
}