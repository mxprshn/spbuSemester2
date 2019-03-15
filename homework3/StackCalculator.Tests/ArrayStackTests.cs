using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackCalculator.Tests
{
    [TestClass()]
    public class ArrayStackTests
    {
        private ArrayStack testStack;

        [TestInitialize()]
        public void Initialize()
        {
            testStack = new ArrayStack();
        }

        [TestMethod()]
        public void SmokePushTest()
        {
            testStack.Push(0);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [TestMethod()]
        public void MultiplePushTest()
        {
            testStack.Push(0);
            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [TestMethod()]
        public void MultipleEqualPushTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                testStack.Push(0);
            }

            Assert.IsFalse(testStack.IsEmpty);
        }

        [TestMethod()]
        public void SmokePopTest()
        {
            var value = 777;
            testStack.Push(value);
            var poppedValue = testStack.Pop();
            Assert.AreEqual(poppedValue, value);
            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        public void MultiplePopTest()
        {
            for (var i = 0; i <= 100; ++i)
            {
                testStack.Push(i);
            }

            for (var i = 100; i >= 0; --i)
            {
                var poppedValue = testStack.Pop();
                Assert.AreEqual(poppedValue, i);
            }

            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyTest()
        {
            _ = testStack.Pop();
        }

        [TestMethod()]
        public void SmokePeekTest()
        {
            var value = 777;
            testStack.Push(value);
            var peekedValue = testStack.Peek();
            Assert.AreEqual(peekedValue, value);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyTest()
        {
            _ = testStack.Peek();
        }

        [TestMethod()]
        public void SmokeClearTest()
        {
            var value = 777;
            testStack.Push(value);
            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        public void MultipleClearTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                testStack.Push(0);
            }

            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        public void ClearEmptyTest()
        {
            testStack.Clear();
            Assert.IsTrue(testStack.IsEmpty);
        }
    }
}