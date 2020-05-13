using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ListFunctionsTests
{
    using ListFunctions;

    public class Tests
    {
        private List<int> list = null;

        [SetUp]
        public void Setup()
        {
            list = new List<int>() { 0, 1, 2, 3, -5, 10, 0 };
        }

        [Test]
        public void SimpleMapTest()
        {
            Assert.IsTrue(ListFunctions.Map(list, (x) => x * 2).SequenceEqual(new List<int> { 0, 2, 4, 6, -10, 20, 0 }));
            Assert.IsTrue(ListFunctions.Map(list, (x) => x * x).SequenceEqual(new List<int> { 0, 1, 4, 9, 25, 100, 0 }));
            Assert.IsTrue(ListFunctions.Map(list, (x) => x - 5).SequenceEqual(new List<int> { -5, -4, -3, -2, -10, 5, -5 }));
        }

        [Test]
        public void MapEmptyListTest()
        {
            ListFunctions.Map(new List<int> { }, (x) => 49 * x + x * x - 15);
        }

        [Test]
        public void SimpleFilterTest()
        {
            Assert.IsTrue(ListFunctions.Filter(list, (x) => x != 0).SequenceEqual(new List<int> { 1, 2, 3, -5, 10 }));
            Assert.IsTrue(ListFunctions.Filter(list, (x) => x % 2 == 0).SequenceEqual(new List<int> { 0, 2, 10, 0 }));
            Assert.IsTrue(ListFunctions.Filter(list, (x) => x > 10).SequenceEqual(new List<int> { }));
        }

        [Test]
        public void FilterEmptyListTest()
        {
            ListFunctions.Filter(new List<int> { }, (x) => x == 420);
        }

        [Test]
        public void SimpleFoldTest()
        {
            Assert.AreEqual(6, ListFunctions.Fold(new List<int> { 1, 2, 3 }, 1, (acc, elem) => acc * elem));
            Assert.AreEqual(0, ListFunctions.Fold(new List<int> { 2, -2 }, 0, (acc, elem) => acc + elem));
            Assert.AreEqual(14, ListFunctions.Fold(new List<int> { 1, 2, 3 }, 0, (acc, elem) => acc + elem * elem));
        }

        [Test]
        public void FoldEmptyListTest()
        {
            ListFunctions.Fold(new List<int> { }, 0, (acc, elem) => acc + elem * elem);
        }

    }
}