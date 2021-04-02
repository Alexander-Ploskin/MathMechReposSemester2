using GenericBubbleSort;
using NUnit.Framework;

namespace GenericBubbleSortTests
{
    public class IntComparerTests
    {
        [SetUp]
        public void Setup()
        {
            comparer = new IntComparer();
        }

        private IntComparer comparer;

        [Test]
        public void CompareTwoPositiveNumbersTest()
        {
            Assert.AreEqual(1, comparer.Compare(2, 1));
            Assert.AreEqual(-1, comparer.Compare(1, 2));
        }

        [Test]
        public void CompareTwoSameNumbersTest()
        {
            Assert.AreEqual(0, comparer.Compare(1, 1));
            Assert.AreEqual(0, comparer.Compare(-1, -1));
        }

        [Test]
        public void CompareTwoNegativeNumbersTest()
        {
            Assert.AreEqual(-1, comparer.Compare(-2, -1));
            Assert.AreEqual(1, comparer.Compare(-1, -2));
        }

    }
}