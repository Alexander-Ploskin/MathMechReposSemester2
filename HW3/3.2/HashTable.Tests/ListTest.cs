using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Tests
{
    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddTest()
        {
            list.Add("Dog");
            Assert.IsTrue(list.Contains("Dog"));
        }

        [TestMethod]
        public void AddOfTwoElementsTest()
        {
            list.Add("Dog");
            list.Add("Cat");
            Assert.IsTrue(list.Contains("Cat"));
            Assert.IsTrue(list.Contains("Dog"));
        }

        [TestMethod]
        public void ResizeTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i.ToString());
            }
            Assert.IsTrue(list.Contains("10"));
        }

        [TestMethod]
        public void NotContainsTest()
        {
            Assert.IsFalse(list.Contains("Dog"));
        }

        [TestMethod]
        public void RemoveByPositionTest()
        {
            list.Add("0");
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");

            list.RemoveByPosition(0);
            Assert.IsFalse(list.Contains("0"));
            list.RemoveByPosition(1);
            Assert.IsFalse(list.Contains("2"));
            list.RemoveByPosition(3);
            Assert.IsFalse(list.Contains("5"));
            list.RemoveByPosition(3);
            Assert.IsTrue(list.Contains("4"));
        }

        [TestMethod]
        public void RemoveByValueTest()
        {
            list.Add("Dog");
            list.Add("Pig"); 
            list.Add("Cat");
            list.RemoveByValue("Cat");
            Assert.IsFalse(list.Contains("Cat"));
            Assert.IsTrue(list.Contains("Dog"));
            Assert.IsTrue(list.Contains("Pig"));
        }

        [TestMethod]
        public void RemoveByValueFromEmptyListTest()
        {
            list.RemoveByValue("Pig");
        }

        [TestMethod]
        public void RemoveByPositionFromEmptyListTest()
        {
            list.RemoveByPosition(10);
        }

        [TestMethod]
        public void PopFromEmptyListTest()
        {
            list.Pop();
        }

        [TestMethod]
        public void PopTest()
        {
            list.Add("Dog");
            Assert.AreEqual(list.Pop(), "Dog");
        }

        [TestMethod]
        public void PopOfTwoElementsTest()
        {
            list.Add("Dog");
            list.Add("Cat");
            Assert.AreEqual(list.Pop(), "Cat");
            Assert.AreEqual(list.Pop(), "Dog");
        }

        private List list;
    }
}
