using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Tests
{
    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable();
        }

        [TestMethod]
        public void ContainsTest()
        {
            hashTable.Add("Dog");
            Assert.IsTrue(hashTable.Contains("Dog"));
        }

        [TestMethod]
        public void ContainsInCaseOfEmptyTableTest()
        {
            Assert.IsFalse(hashTable.Contains("Dog"));
        }

        [TestMethod]
        public void RemoveTest()
        {
            hashTable.Add("Dog");
            hashTable.Remove("Dog");
            Assert.IsFalse(hashTable.Contains("Dog"));
        }

        [TestMethod]
        public void ResizeTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hashTable.Add(i.ToString());
            }
            Assert.IsTrue(hashTable.Contains("12"));
        }

        [TestMethod]
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

        [TestMethod]
        public void AddOfTwoSameStringsTest()
        {
            hashTable.Add("Scooby doo");
            hashTable.Add("Scooby doo");
            hashTable.Add("Scooby doo");
            Assert.IsTrue(hashTable.Contains("Scooby doo"));
        }


        [TestMethod]
        public void RemoveOfNotContainedStringTest()
        {
            hashTable.Add("1");
            hashTable.Remove("2");
        }

        [TestMethod]
        public void RemoveFromEmptyTableTest()
        {
            hashTable.Remove("222");
        }

        HashTable hashTable;
    }
}
