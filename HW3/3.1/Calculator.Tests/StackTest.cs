using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackTest
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new ListStack();
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
            Assert.ThrowsException<PopFromEmptyStackException>(() => stack.Pop());
        }

        [TestMethod]
        public void PushOfTwoElementsTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }

        private ListStack stack;
    }
}