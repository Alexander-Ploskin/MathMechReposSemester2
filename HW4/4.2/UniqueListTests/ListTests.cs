using NUnit.Framework;

namespace UniqueListTests
{
    using UniqueList;

    public class ListTests
    {
        private List list;

        [SetUp]
        public void Initialize()
        {
            list = new List();
        }

        [Test]
        public void AdditionToEmptyListTest()
        {
            list.Add(5, 0);
            Assert.IsTrue(list.Contains(5));
            Assert.AreEqual(1, list.Length());
        }

        [Test]
        public void AdditionToNotEmptyListTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(0));
            Assert.AreEqual(list.Length(), 2);
        }

        [Test]
        public void AdditionToHeadOfNotEmptyListTest()
        {
            list.Add(0, 0);
            list.Add(1, 0);
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(0));
            Assert.AreEqual(list.Length(), 2);
        }

        [Test]
        public void AdditionToNotHeadPositionOfBigList()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 1);
            Assert.IsTrue(list.Contains(1));
            Assert.IsTrue(list.Contains(0));
            Assert.IsTrue(list.Contains(2));
            Assert.AreEqual(list.Length(), 3);
        }

        [Test]
        public void AdditionByNegativePositionTest()
        {
            Assert.Throws<InvalidPositionException>(() => list.Add(5, -7));
        }

        [Test]
        public void AdditionByNotExistPositionTest()
        {
            list.Add(2, 0);
            list.Add(3, 1);
            Assert.Throws<InvalidPositionException>(() => list.Add(5, 7));
            Assert.AreEqual(list.Length(), 2);
        }

        [Test]
        public void GetValueByInvalidPositionTest()
        {
            Assert.Throws<InvalidPositionException>(() => list.GetValueOfElementByPosition(-1));
            Assert.Throws<InvalidPositionException>(() => list.GetValueOfElementByPosition(0));
        }

        [Test]
        public void SetValueOnInvalidPositionTest()
        {
            Assert.Throws<InvalidPositionException>(() => list.SetValueOnPosition(-1, 1));
            Assert.Throws<InvalidPositionException>(() => list.SetValueOnPosition(1, 1));
        }

        [Test]
        public void RemoveByValueFromEmptyListTest()
        {
            Assert.Throws<RemoveFromEmptyListException>(() => list.RemoveByValue(5));
        }

        [Test]
        public void RemoveByInvalidPositionTest()
        {
            list.Add(0, 0);
            Assert.Throws<RemoveByNotExistPositionException>(() => list.RemoveByPosition(7));
            Assert.Throws<RemoveByNotExistPositionException>(() => list.RemoveByPosition(-1));
            Assert.AreEqual(list.Length(), 1);
        }

        [Test]
        public void RemoveByPositionFromEmptyListTest()
        {
            Assert.Throws<RemoveFromEmptyListException>(() => list.RemoveByPosition(1));
        }

        [Test]
        public void RemoveByNullPositionTest()
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.RemoveByPosition(0);
            Assert.IsTrue(list.Contains(2));
            Assert.IsFalse(list.Contains(1));
            Assert.AreEqual(list.Length(), 1);
        }

        [Test]
        public void RemoveByMiddlePositionTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.Add(3, 3);
            list.RemoveByPosition(2);
            Assert.IsTrue(list.Contains(1));
            Assert.IsFalse(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.AreEqual(list.Length(), 3);
        }

        [Test]
        public void RemoveByTailPositionTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.RemoveByPosition(2);
            Assert.IsFalse(list.Contains(2));
            Assert.AreEqual(list.Length(), 2);
        }

        [Test]
        public void RemoveByValueFromHeadTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.RemoveByValue(0);
            Assert.IsTrue(list.Contains(1));
            Assert.IsFalse(list.Contains(0));
            Assert.AreEqual(list.Length(), 1);
        }

        [Test]
        public void RemoveByValueFromTailTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.RemoveByValue(1);
            Assert.IsTrue(list.Contains(0));
            Assert.IsFalse(list.Contains(1));
            Assert.AreEqual(list.Length(), 1);
        }

        [Test]
        public void RemoveByValueFromMidTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.RemoveByValue(1);
            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(0));
            Assert.IsFalse(list.Contains(1));
            Assert.AreEqual(list.Length(), 2);
        }

        [Test]
        public void SetValueTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.SetValueOnPosition(1, 3);
            Assert.IsTrue(list.Contains(3));
            Assert.IsFalse(list.Contains(1));
            Assert.AreEqual(list.Length(), 3);
        }

        [Test]
        public void GetValueTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            Assert.AreEqual(list.GetValueOfElementByPosition(0), 0);
            Assert.AreEqual(list.GetValueOfElementByPosition(1), 1);
            Assert.AreEqual(list.GetValueOfElementByPosition(2), 2);
        }
    }
}
