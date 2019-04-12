using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        private PriorityQueue testQueue;

        [SetUp]
        public void SetUp()
        {
            testQueue = new PriorityQueue();
        }

        [Test]
        public void EnqueueSmokeTest()
        {
            testQueue.Enqueue(10, 100);
            Assert.IsFalse(testQueue.IsEmpty);
        }

        [Test]
        public void MultipleEnqueueTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                testQueue.Enqueue(i, i);
            }

            Assert.IsFalse(testQueue.IsEmpty);
        }

        [Test]
        public void SamePriorityEnqueueTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                testQueue.Enqueue(0, i);
            }

            Assert.IsFalse(testQueue.IsEmpty);
        }

        [TestCaseSource("TestValues")]
        public void DequeueTests((int, int)[] addValues, int[] expectedValues)
        {
            foreach (var current in addValues)
            {
                testQueue.Enqueue(current.Item1, current.Item2);
            }

            foreach (var current in expectedValues)
            {
                Assert.AreEqual(current, testQueue.Dequeue());
            }

            Assert.IsTrue(testQueue.IsEmpty);
        }

        [Test]
        public void DequeueFromEmptyTest()
        {
            Assert.Throws<DequeueFromEmptyException>(() => _ = testQueue.Dequeue());
        }

        private static object[] TestValues =
        {
            new object[]
            {
                new (int, int)[] { (0, 10) },
                new int[] { 10 },
            },

            new object[]
            {
                new (int, int)[] { (10, 1), (20, 2), (30, 3) },
                new int[] { 3, 2, 1 },
            },

            new object[]
            {
                new (int, int)[] { (30, 3), (20, 2), (10, 1) },
                new int[] { 3, 2, 1 },
            },

            new object[]
            {
                new (int, int)[] { (10, 3), (10, 2), (10, 1) },
                new int[] { 3, 2, 1 },
            },

            new object[]
            {
                new (int, int)[] { (-1, 10), (-1, 20), (-1, 30) },
                new int[] { 10, 20, 30 },
            },

            new object[]
            {
                new (int, int)[] { (1000, 1), (1000, 2), (100, 3), (1, 4), (100, 5), (10000, 6) },
                new int[] { 6, 1, 2, 3, 5, 4 },
            },

            new object[]
            {
                new (int, int)[] { (0, 1), (-100, 2), (-200, 3), (-200, 4), (-100, 5), (0, 6) },
                new int[] { 1, 6, 2, 5, 3, 4 },
            },

            new object[]
            {
                new (int, int)[] { (1000, 0), (1000, 0), (1000, 0), (1000, 0), (1000, 0), (1000, 0) },
                new int[] { 0, 0, 0, 0, 0, 0 },
            },

            new object[]
            {
                new (int, int)[] { (300, 1), (2000, 2), (300, 3), (2000, 4), (300, 5), (2000, 6) },
                new int[] { 2, 4, 6, 1, 3, 5 },
            },
        };
    }
}