using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListTests
{
    using UniqueList;

    [TestClass]
    public class ListTests
    {
        private List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AdditionToEmptyListTest()
        {
            list.Add(5, 0);
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Length() == 1);
        }

        [TestMethod]
        public void AdditionToNotEmptyListTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            Assert.IsTrue(list.Contains(1) && list.Contains(0));
            Assert.IsTrue(list.Length() == 2);
        }

        [TestMethod]
        public void AdditionToHeadOfNotEmptyListTest()
        {
            list.Add(0, 0);
            list.Add(1, 0);
            Assert.IsTrue(list.Contains(1) && list.Contains(0));
            Assert.IsTrue(list.Length() == 2);
        }

        [TestMethod]
        public void AdditionToNotHeadPositionOfBigList()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 1);
            Assert.IsTrue(list.Contains(1) && list.Contains(0) && list.Contains(2));
            Assert.IsTrue(list.Length() == 3);
        }

        [TestMethod]
        public void AdditionByNegativePositionTest()
        {
            Assert.ThrowsException<InvalidPositionException>(() => list.Add(5, -7));
        }

        [TestMethod]
        public void AdditionByNotExistPositionTest()
        {
            list.Add(2, 0);
            list.Add(3, 1);
            Assert.ThrowsException<InvalidPositionException>(() => list.Add(5, 7));
            Assert.IsTrue(list.Length() == 2);
        }

        [TestMethod]
        public void GetValueByInvalidPositionTest()
        {
            Assert.ThrowsException<InvalidPositionException>(() => list.GetValueOfElementByPosition(-1));
            Assert.ThrowsException<InvalidPositionException>(() => list.GetValueOfElementByPosition(0));
        }

        [TestMethod]
        public void SetValueOnInvalidPositionTest()
        {
            Assert.ThrowsException<InvalidPositionException>(() => list.SetValueOnPosition(-1, 1));
            Assert.ThrowsException<InvalidPositionException>(() => list.SetValueOnPosition(1, 1));
        }

        [TestMethod]
        public void RemoveByValueFromEmptyListTest()
        {
            Assert.ThrowsException<RemoveFromEmptyListException>(() => list.RemoveByValue(5));
        }

        [TestMethod]
        public void RemoveByInvalidPositionTest()
        {
            list.Add(0, 0);
            Assert.ThrowsException<RemoveByNotExistPositionException>(() => list.RemoveByPosition(7));
            Assert.ThrowsException<RemoveByNotExistPositionException>(() => list.RemoveByPosition(-1));
            Assert.IsTrue(list.Length() == 1);
        }

        [TestMethod]
        public void RemoveByPositionFromEmptyListTest()
        {
            Assert.ThrowsException<RemoveFromEmptyListException>(() => list.RemoveByPosition(1));
        }

        [TestMethod]
        public void RemoveByNullPositionTest()
        {
            list.Add(1, 0);
            list.Add(2, 1);
            list.RemoveByPosition(0);
            Assert.IsTrue(!list.Contains(1) && list.Contains(2));
            Assert.IsTrue(list.Length() == 1);
        }

        [TestMethod]
        public void RemoveByMiddlePositionTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.Add(3, 3);
            list.RemoveByPosition(2);
            Assert.IsTrue(list.Contains(1) && list.Contains(3) && !list.Contains(2));
            Assert.IsTrue(list.Length() == 3);
        }

        [TestMethod]
        public void RemoveByTailPositionTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.RemoveByPosition(2);
            Assert.IsFalse(list.Contains(2));
            Assert.IsTrue(list.Length() == 2);
        }

        [TestMethod]
        public void RemoveByValueFromHeadTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.RemoveByValue(0);
            Assert.IsTrue(list.Contains(1) && !list.Contains(0) && list.Length() == 1);
        }

        [TestMethod]
        public void RemoveByValueFromTailTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.RemoveByValue(1);
            Assert.IsTrue(list.Contains(0) && !list.Contains(1) && list.Length() == 1);
        }

        [TestMethod]
        public void RemoveByValueFromMidTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.RemoveByValue(1);
            Assert.IsTrue(list.Contains(2) && list.Contains(0) && !list.Contains(1) && list.Length() == 2);
        }

        [TestMethod]
        public void SetValueTest()
        {
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 2);
            list.SetValueOnPosition(1, 3);
            Assert.IsTrue(list.Contains(3) && !list.Contains(1) && list.Length() == 3);
        }

        [TestMethod]
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
