using NUnit.Framework;

namespace UniqueListTests
{
    using UniqueList; 

    public class UniqueListTests
    {
        private UniqueList list;

        [SetUp]
        public void Initialize()
        {
            list = new UniqueList();
            list.Add(4, 0);
        }

        [Test]
        public void SimpleAdditionTest()
        {
            list.Add(5, 1);
            Assert.IsTrue(list.Contains(5));
        }

        [Test]
        public void AdditionOfAlreadyContainedValueTest()
        {
            Assert.Throws<AdditionOfContainedElementException>(() => list.Add(4, 0));
            Assert.Throws<AdditionOfContainedElementException>(() => list.Add(4, 1));
        }
    }
}