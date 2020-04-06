using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListTests
{
    using UniqueList;

    [TestClass]
    public class UniqueListTests
    { 
        private UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
            list.Add(4, 0);
        }

        [TestMethod]
        public void SimpleAdditionTest()
        {
            list.Add(5, 1);
            Assert.IsTrue(list.Contains(5));
        }

        [TestMethod]
        public void AdditionOfAlreadyContainedValueTest()
        {
            Assert.ThrowsException<AdditionOfContainedElementException>(() => list.Add(4, 0));
            Assert.ThrowsException<AdditionOfContainedElementException>(() => list.Add(4, 1));
        }
    }
}
