using NUnit.Framework;

namespace HashTableTests
{
    using HashTable;

    class ListTests
    {
        [SetUp]
        public void SetUp()
        {
            list = new List();
        }

        [Test]
        public void AddTest()
        {
            list.Add("Dog");
            Assert.IsTrue(list.Contains("Dog"));
        }

        [Test]
        public void AddOfTwoElementsTest()
        {
            list.Add("Dog");
            list.Add("Cat");
            Assert.IsTrue(list.Contains("Cat"));
            Assert.IsTrue(list.Contains("Dog"));
        }

        [Test]
        public void ResizeTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                list.Add(i.ToString());
            }
            Assert.IsTrue(list.Contains("10"));
        }

        [Test]
        public void NotContainsTest()
        {
            Assert.IsFalse(list.Contains("Dog"));
        }

        [Test]
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

        [Test]
        public void RemoveByValueFromEmptyListTest()
        {
            list.RemoveByValue("Pig");
        }

        [Test]
        public void PopFromEmptyListTest()
        {
            list.Pop();
        }

        [Test]
        public void PopTest()
        {
            list.Add("Dog");
            Assert.AreEqual(list.Pop(), "Dog");
        }

        [Test]
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
