using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MySetTests
{
    using MySet;
    using System.Linq;

    public class Tests
    {
        private MySet<int> set;

        [SetUp]
        public void Setup()
        {
            set = new MySet<int>(new IntComparer()) { 1, 2, -10, 5, -14,-12, 3 };
        }

        [Test]
        public void EnumTest()
        {
            var previous = -1000;
            foreach (var item in set)
            {
                if (previous < item)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void SimpleAdditionTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(1);
            Assert.IsTrue(set.Contains(1));
        }

        [Test]
        public void AdditionOfTwoSameItemsTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(0);
            Assert.IsFalse(set.Add(0));
        }

        [Test]
        public void AdditionInOrderTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(0);
            set.Add(1);
            set.Add(2);
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
        }

        [Test]
        public void AdditionPreOrderTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(2);
            set.Add(1);
            set.Add(0);
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(0));
        }

        [Test]
        public void AdditionOfManyItemsTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(1);
            set.Add(2);
            set.Add(-10);
            set.Add(-14);
            set.Add(5);
            set.Add(-12);
            set.Add(3);
            set.Add(4);
            Assert.IsTrue(set.Contains(1) && set.Contains(2) && set.Contains(-10)
               && set.Contains(-14) && set.Contains(5) && set.Contains(-12)
               && set.Contains(3) && set.Contains(4));
        }

        [Test]
        public void ClearTest()
        {
            set.Clear();
            Assert.IsEmpty(set);
        }

        [Test]
        public void ContainsTest()
        {
            Assert.IsTrue(set.Contains(-14) && set.Contains(1) && set.Contains(3));
            Assert.IsFalse(set.Contains(0) || set.Contains(-15) || set.Contains(4));
        }

        [Test]
        public void CopyToTest()
        {
            var array = new int[7];
            set.CopyTo(array, 0);
            Assert.IsTrue(array.SequenceEqual(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
        }

        [Test]
        public void ExceptWithTest()
        {
            set.ExceptWith(new int[7] { -14, 10, -10, 1, 6, 5, 19 });
            Assert.IsTrue(set.SetEquals(new int[3] { -12, 2, 3 }));
        }

        [Test]
        public void IntersectWithTest()
        {
            set.IntersectWith(new int[7] { -14, 10, -10, 1, 6, 5, 19 });
            Assert.IsTrue(new int[4] { -14, -10, 1, 5 }.Equals(set));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(set.IsSubsetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsTrue(set.IsSubsetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(set.IsSubsetOf(new int[6] { -14, -12, -10, 1, 3, 5 }));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(set.IsProperSubsetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsFalse(set.IsProperSubsetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(set.IsProperSubsetOf(new int[6] { -14, -12, -10, 1, 3, 5 }));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsFalse(set.IsSupersetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsTrue(set.IsSupersetOf(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsTrue(set.IsSupersetOf(new int[10] { -14, -14, -10, 1, 3, 5, 10, 3, 3, 5 }));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsFalse(set.IsProperSupersetOf(new int[10] { -14, -12, -10, 1, 2, 3, 5, -10, 30, 45 }));
            Assert.IsFalse(set.IsProperSupersetOf(new int[12] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2, 3, 3 }));
            Assert.IsTrue(set.IsProperSupersetOf(new int[10] { -14, -14, -10, 1, 3, 5, 10, 3, 3, 5 }));
        }

        [Test]
        public void OverlapsTest()
        {
            Assert.IsTrue(set.Overlaps(new int[10] { -14, -4, -14, 6, 2, 2, 1, 15, 30, 45 }));
            Assert.IsTrue(set.Overlaps(new int[7] { -14, -12, -10, 1, 2, 3, 5 }));
            Assert.IsFalse(set.Overlaps(new int[10] { -13, -4, -100, 6, 16, 11, 7, 15, 30, 45 }));
        }

        [Test]
        public void RemoveFirstItemTest()
        {
            set.Remove(1);
            Assert.IsTrue(!set.Contains(1) && set.Contains(2) && set.Contains(-10)
               && set.Contains(-14) && set.Contains(5) && set.Contains(-12)
               && set.Contains(3) && set.Contains(4));
        }

        [Test]
        public void RemoveSecondAItemTest()
        {
            set.Add(-9);
            set.Remove(-10);
            Assert.IsTrue(set.Contains(1) && set.Contains(2) && !set.Contains(-10)
               && set.Contains(-14) && set.Contains(5) && set.Contains(-12)
               && set.Contains(3) && set.Contains(4) && set.Contains(9));
        }

        [Test]
        public void RemoveOfOneItemTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Add(1);
            set.Remove(1);
            Assert.IsFalse(set.Contains(1));
        }

        [Test]
        public void RemoveFromEmptySetTest()
        {
            set = new MySet<int>(new IntComparer());
            set.Remove(1);
        }

        [Test]
        public void RemoveOfThirdItemTest()
        {
            set.Remove(2);
            Assert.IsTrue(set.Contains(1) && !set.Contains(2) && set.Contains(-10)
               && set.Contains(-14) && set.Contains(5) && set.Contains(-12)
               && set.Contains(3) && set.Contains(4));
        }

        [Test]
        public void RemoveOfLastItemsTest()
        {
            set.Remove(-14);
            set.Remove(5);
            Assert.IsTrue(!set.Contains(1) && set.Contains(2) && set.Contains(-10)
               && set.Contains(-14) && !set.Contains(5) && set.Contains(-12)
               && set.Contains(3) && set.Contains(4));

        }

        [Test]
        public void SetEqualsTest()
        {
            Assert.IsTrue(set.SetEquals(new int[10] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2 }));
            Assert.IsFalse(set.SetEquals(new int[11] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2, 7 }));
            Assert.IsFalse(set.SetEquals(new int[10] { -14, -14, -10, 1, 2, 3, 5, -14, 1, 2 }));
        }

        [Test]
        public void SymmetricExceptWith()
        {
            set.SymmetricExceptWith(new int[10] { -14, -12, -10, 1, 2, 3, 5, -14, 1, 2 });
            Assert.IsTrue(set.SetEquals(new int[0] { }));
            set.SymmetricExceptWith(new int[5] { -14, -10, 4, 4, 11 });
            Assert.IsTrue(set.SetEquals(new int[7] { 1, 2, 4, 5, 11, -12, 3 }));
        }

        [Test]
        public void UnionWithTest()
        {
            set.UnionWith(new int[6] { -14, -14, 5, 4, 11, -10 });
            Assert.IsTrue(set.SetEquals(new int[9] { 1, 2, -10, 5, -14, -12, 3, 4, 11 }));
        }

    }
}