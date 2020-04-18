using NUnit.Framework;

namespace HashTableTests
{
    using HashTable;

    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            hashTable = new HashTable();
        }

        [Test]
        public void ContainsTest()
        {
            hashTable.Add("Dog");
            Assert.IsTrue(hashTable.Contains("Dog"));
        }

        [Test]
        public void ContainsInCaseOfEmptyTableTest()
        {
            Assert.IsFalse(hashTable.Contains("Dog"));
        }

        [Test]
        public void RemoveTest()
        {
            hashTable.Add("Dog");
            hashTable.Remove("Dog");
            Assert.IsFalse(hashTable.Contains("Dog"));
        }

        [Test]
        public void ResizeTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hashTable.Add(i.ToString());
            }
            Assert.IsTrue(hashTable.Contains("12"));
        }

        [Test]
        public void ChangeFunctionTest()
        {
            hashTable.Add("Pig");
            hashTable.Add("Cow");
            hashTable.Add("Chicken");
            hashTable.Add("Goose");
            hashTable.Add("Turkey");
            var instanceOfFunction = new SimpleHashFunction();
            hashTable.ChangeHashFunction(instanceOfFunction);
            Assert.IsTrue(hashTable.Contains("Goose"));
        }

        [Test]
        public void AddOfTwoSameStringsTest()
        {
            hashTable.Add("Scooby doo");
            hashTable.Add("Scooby doo");
            Assert.IsTrue(hashTable.Contains("Scooby doo"));
        }


        [Test]
        public void RemoveOfNotContainedStringTest()
        {
            hashTable.Add("1");
            hashTable.Remove("2");
        }

        [Test]
        public void RemoveFromEmptyTableTest()
        {
            hashTable.Remove("222");
        }

        private HashTable hashTable;
    }
}