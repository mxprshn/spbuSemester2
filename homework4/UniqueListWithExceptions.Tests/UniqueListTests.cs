using NUnit.Framework;
using System.IO;

namespace UniqueListWithExceptions.Tests
{
    [TestFixture]
    public class UniqueListTests
    {
        private UniqueList testList;
        private StreamReader testFileReader;

        [SetUp]
        public void SetUp()
        {
            testList = new UniqueList();
            testFileReader = new StreamReader(TestContext.CurrentContext.TestDirectory + ".\\UniqueListTestsStrings.txt");
        }

        [TearDown]
        public void TearDown()
        {
            testFileReader.Close();
        }

        [Test]
        public void SmokeInsertFirstTest()
        {
            var newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.AreEqual(newString, testList[0]);
            Assert.AreEqual(1, testList.Length);
        }

        [Test]
        public void EqualStringsInsertFirstTest()
        {
            var newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.Throws<ExistingElementInsertionException>(() => testList.InsertFirst(newString));
        }

        [Test]
        public void MultipleInsertFirstTest()
        {
            while (!testFileReader.EndOfStream)
            {
                testList.InsertFirst(testFileReader.ReadLine());
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (var i = testList.Length - 1; i >= 0; --i)
            {
                Assert.AreEqual(testFileReader.ReadLine(), testList[i]);
            }
        }

        [Test]
        public void SmokeInsertAfterTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertAfter(newString2, 0);
            Assert.AreEqual(newString2, testList[1]);
        }

        [Test]
        public void EqualStringsInsertAfterTest()
        {
            var newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.Throws<ExistingElementInsertionException>(() => testList.InsertAfter(newString, 0));
        }

        [Test]
        public void EmptyListInsertAfterTest()
        {
            var newString = "Hello, World!!!";
            Assert.Throws<EmptyListOperationException>(() => testList.InsertAfter(newString, 3));
        }

        [Test]
        public void IncorrectIndexInsertAfterTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            Assert.Throws<IncorrectIndexException>(() => testList.InsertAfter(newString2, -11));
        }

        [Test]
        public void MiddleInsertAfterTest()
        {
            var newString1 = "First string";
            var newString2 = "Second string";
            var newString3 = "Third string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString1);
            testList.InsertAfter(newString2, 0);
            Assert.AreEqual(newString2, testList[1]);
        }

        [Test]
        public void MultipleToEndInsertAfterTest()
        {
            testList.InsertFirst(testFileReader.ReadLine());

            while (!testFileReader.EndOfStream)
            {
                testList.InsertAfter(testFileReader.ReadLine(), testList.Length - 1);
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (var i = 0; i < testList.Length; ++i)
            {
                Assert.AreEqual(testFileReader.ReadLine(), testList[i]);
            }
        }
    }
}