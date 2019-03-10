using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var poppedValue = testStack.Pop(out bool result);
            Assert.AreEqual(poppedValue, value);
            Assert.IsTrue(result);
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
                var poppedValue = testStack.Pop(out bool result);
                Assert.AreEqual(poppedValue, i);
                Assert.IsTrue(result);
            }

            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        public void PopFromEmptyTest()
        {
            var poppedValue = testStack.Pop(out bool result);
            Assert.AreEqual(poppedValue, -1);
            Assert.IsFalse(result);
            Assert.IsTrue(testStack.IsEmpty);
        }

        [TestMethod()]
        public void SmokePeekTest()
        {
            var value = 777;
            testStack.Push(value);
            var peekedValue = testStack.Peek(out bool result);
            Assert.AreEqual(peekedValue, value);
            Assert.IsTrue(result);
            Assert.IsFalse(testStack.IsEmpty);
        }

        [TestMethod()]
        public void PeekFromEmptyTest()
        {
            var peekedValue = testStack.Peek(out bool result);
            Assert.AreEqual(peekedValue, -1);
            Assert.IsFalse(result);
            Assert.IsTrue(testStack.IsEmpty);
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