using NUnit.Framework;
using System;

namespace StackCalculator.Tests
{
    [TestFixture(typeof(ListStack))]
    [TestFixture(typeof(ArrayStack))]
    public class StackTests<TStack> where TStack : IStack, new()
    {
        private IStack testStack;

        [SetUp]
        public void Initialize()
        {
            testStack = new TStack();
        }

        [Test]
        public void SmokePushTest()
        {
            testStack.Push(0);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [Test]
        public void MultiplePushTest()
        {
            testStack.Push(0);
            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [Test]
        public void MultipleEqualPushTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                testStack.Push(0);
            }

            Assert.IsFalse(testStack.IsEmpty);
        }

        [Test]
        public void SmokePopTest()
        {
            var value = 777;
            testStack.Push(value);
            var poppedValue = testStack.Pop();
            Assert.AreEqual(value, poppedValue);
            Assert.IsTrue(testStack.IsEmpty);
        }

        [Test]
        public void MultiplePopTest()
        {
            for (var i = 0; i <= 100; ++i)
            {
                testStack.Push(i);
            }

            for (var i = 100; i >= 0; --i)
            {
                var poppedValue = testStack.Pop();
                Assert.AreEqual(i, poppedValue);
            }

            Assert.IsTrue(testStack.IsEmpty);
        }

        [Test]
        public void PopFromEmptyTest()
        {
            Assert.Throws<InvalidOperationException>(() => testStack.Pop());
        }

        [Test]
        public void SmokePeekTest()
        {
            var value = 777;
            testStack.Push(value);
            var peekedValue = testStack.Peek();
            Assert.AreEqual(value, peekedValue);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [Test]
        public void PeekFromEmptyTest()
        {
            Assert.Throws<InvalidOperationException>(() => testStack.Peek());
        }

        [Test]
        public void SmokeClearTest()
        {
            var value = 777;
            testStack.Push(value);
            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }

        [Test]
        public void MultipleClearTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                testStack.Push(0);
            }

            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }

        [Test]
        public void ClearEmptyTest()
        {
            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }
    }
}