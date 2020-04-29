using NUnit.Framework;

namespace QueueTests
{
    using PriotiryQueue;

    public class Tests
    {
        private Queue<int> queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue<int>();
        }

        [Test]
        public void DequeueFromEmptyTest()
        {
            try
            {
                queue.Dequeue();
            }
            catch (DequeueFromEmptyQueueException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void SimpleDequeueTest()
        {
            queue.Enqueue(1, 1);
            Assert.AreEqual(1, queue.Dequeue());
        }

        [Test]
        public void AdditionOfThreeElementsWithSameKeyTest()
        {
            queue.Enqueue(1, 1);
            queue.Enqueue(2, 1);
            queue.Enqueue(3, 1);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }

        [Test]
        public void AdditionOfTwoElementsWithNotSameKeyTest()
        {
            queue.Enqueue(2, 1);
            queue.Enqueue(1, 3);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
        }

        [Test]
        public void AdditionOfTwoSameElementsTest()
        {
            queue.Enqueue(1, 1);
            queue.Enqueue(1, 1);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
        }

        [Test]
        public void MakeQueueEmptyTest()
        {
            queue.Enqueue(1, 1);
            queue.Dequeue();
            try
            {
                queue.Dequeue();
            }
            catch (DequeueFromEmptyQueueException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void AdditionOfThreeElementsWithNotSamePriorityTest()
        {
            queue.Enqueue(2, 1);
            queue.Enqueue(3, 1);
            queue.Enqueue(1, 2);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }

    }
}