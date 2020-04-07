using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListFunctionsTests
{
    using ListFunctions;

    [TestClass]
    public class ListFunctionsTests
    {
        private List<int> list = null;

        [TestInitialize]

        public void Initialize()
        {
            list = new List<int>() { 0, 1, 2, 3, -5, 10, 0};
        }

        [TestMethod]
        public void SimpleMapTest()
        {
            Assert.AreEqual(new List<int> { 0, 2, 4, 6, -10, 20, 0 }, ListFunctions.Map(list, (x) => x * 2));
            Assert.AreEqual(new List<int> { 0, 1, 4, 9, 25, 100, 0 }, ListFunctions.Map(list, (x) => x * x));
            Assert.AreEqual(new List<int> { -5, -4, -3, -2, -10, 5, -5 }, ListFunctions.Map(list, (x) => x * 2));
        }

        [TestMethod]
        public void MapEmptyListTest()
        {
            Assert.ThrowsException<Exception>(() => ListFunctions.Map(new List<int> { }, (x) => 49 * x + x * x - 15));
        }

        [TestMethod]
        public void SimpleFilterTest()
        {
            Assert.AreEqual(new List<int> { 1, 2, 3, -5, 10 }, ListFunctions.Filter(list, (x) => x != 0));
            Assert.AreEqual(new List<int> { 2 }, ListFunctions.Filter(list, (x) => x % 2 == 0));
            Assert.AreEqual(new List<int> { }, ListFunctions.Filter(list, (x) => x > 10));
        }

        [TestMethod]
        public void FilterEmptyListTest()
        {
            Assert.ThrowsException<Exception>(() => ListFunctions.Filter(new List<int> { }, (x) => x == 420));
        }

        [TestMethod]
        public void SimpleFoldTest()
        {
            Assert.AreEqual(6, ListFunctions.Fold(new List<int> { 1, 2, 3 }, 1, (acc, elem) => acc * elem));
            Assert.AreEqual(0, ListFunctions.Fold(new List<int> { 2, -2 }, 0, (acc, elem) => acc + elem));
            Assert.AreEqual(14, ListFunctions.Fold(new List<int> { 1, 2, 3 }, 0, (acc, elem) => acc + elem * elem));
        }

        [TestMethod]
        public void FoldEmptyListTest()
        {
            Assert.ThrowsException<Exception>(() => ListFunctions.Fold(new List<int> { }, 0, (acc, elem) => acc + elem * elem));
        }

    }
}
