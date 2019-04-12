using NUnit.Framework;

namespace WalkingDog.Tests
{
    [TestFixture]
    public class DogTests
    {
        private Dog testDog;

        [SetUp]
        public void SetUp()
        {
            testDog = new Dog(0, 0);
        }

        [Test]
        public void MoveLeftTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                testDog.MoveLeft();
            }

            Assert.AreEqual(-10, testDog.LeftPosition);
            Assert.AreEqual(0, testDog.TopPosition);
        }

        [Test]
        public void MoveRightTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                testDog.MoveRight();
            }

            Assert.AreEqual(10, testDog.LeftPosition);
            Assert.AreEqual(0, testDog.TopPosition);
        }

        [Test]
        public void MoveUpTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                testDog.MoveUp();
            }

            Assert.AreEqual(0, testDog.LeftPosition);
            Assert.AreEqual(-10, testDog.TopPosition);
        }

        [Test]
        public void MoveDownTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                testDog.MoveDown();
            }

            Assert.AreEqual(0, testDog.LeftPosition);
            Assert.AreEqual(10, testDog.TopPosition);
        }
    }
}