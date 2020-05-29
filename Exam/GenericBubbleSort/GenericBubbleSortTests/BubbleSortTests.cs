using GenericBubbleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GenericBubbleSortTests
{
    class BubbleSortTests
    {
        [SetUp]
        public void Setup()
        {
            comparer = new IntComparer();
        }

        private bool IsSorted(List<int> list)
        {
            if (list.Count == 0)
            {
                return true;
            }

            int lastItem = list[0];
            foreach (var item in list)
            {
                if (item < lastItem)
                {
                    return false;
                }
            }

            return true;
        }

        private static IEnumerable<List<int>> Lists()
        {
            yield return new List<int>() { -1, -13, 90, 123, 23, 1 };
            yield return new List<int>() { 1, 2, 3, 4, 5 };
            yield return new List<int>() { -1, -2, -3, -4, -5 };
            yield return new List<int>() { 1, 0 };
            yield return new List<int>();
            yield return new List<int>() { -100, 100, -100, 100, -100, 100 };
            yield return new List<int>() { 0, 1 };
            yield return new List<int>() { 0 };
        }

        [TestCaseSource("Lists")]
        public void SimpleListsTest(List<int> inputedList)
        {
            var actualOutput = ListFuncs<int>.BubbleSort(inputedList, comparer);
            Assert.IsTrue(IsSorted(actualOutput));
        }

        [Test]
        public void SortBigListTest()
        {
            var list = new List<int>();
            for (int i = 0; i < 10000; ++i)
            {
                list.Add(new Random().Next(-10, 10));
            }

            var output = ListFuncs<int>.BubbleSort(list, comparer);
            Assert.IsTrue(IsSorted(output));
        }

        private IntComparer comparer;
    }
}
