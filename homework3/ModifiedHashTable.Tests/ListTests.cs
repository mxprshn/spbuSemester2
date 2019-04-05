using NUnit.Framework;
using System;
using System.IO;

namespace SinglyLinkedList.Tests
{
    [TestFixture]
    public class ListTests
    {
        private List testList;
        private StreamReader testFileReader;

        [SetUp]
        public void SetUp()
        {
            testList = new List();
            testFileReader = new StreamReader(TestContext.CurrentContext.TestDirectory + ".\\ListTestsStrings.txt");
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
            testList.InsertFirst(newString);
            Assert.AreEqual(newString, testList[1]);
            Assert.AreEqual(newString, testList[0]);
            Assert.AreEqual(2, testList.Length);
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
        public void EmptyListInsertAfterTest()
        {
            var newString = "Hello, World!!!";
            Assert.Throws<InvalidOperationException>(() => testList.InsertAfter(newString, 3));
        }

        [Test]
        public void IncorrectIndexInsertAfterTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.InsertAfter(newString2, -11));
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

        [Test]
        public void DoubleMultipleInsertAfterTest()
        {
            testList.InsertFirst(testFileReader.ReadLine());

            while (!testFileReader.EndOfStream)
            {
                testList.InsertAfter(testFileReader.ReadLine(), testList.Length - 1);
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            var lengthAfterFirstInsert = testList.Length;

            for (var i = 0; i < lengthAfterFirstInsert; ++i)
            {
                testList.InsertAfter(testFileReader.ReadLine(), i * 2);
            }

            for (var i = 0; i < testList.Length / 2; ++i)
            {
                Assert.AreEqual(testList[i * 2], testList[(i * 2) + 1]);
            }
        }

        [Test]
        public void SmokeRemoveFirstTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            testList.RemoveFirst();
            Assert.AreEqual(newString1, testList[0]);
            Assert.AreEqual(1, testList.Length);
        }

        [Test]
        public void EmptyListRemoveFirstTest()
        {
            Assert.Throws<InvalidOperationException>(() => testList.RemoveFirst());
        }

        [Test]
        public void MultipleRemoveFirstTest()
        {
            while (!testFileReader.EndOfStream)
            {
                testList.InsertFirst(testFileReader.ReadLine());
            }

            const int ExpectedLength = 50;

            for (var i = 0; i < ExpectedLength; ++i)
            {
                testList.RemoveFirst();
            }

            Assert.AreEqual(0, testList.Length);
        }

        [Test]
        public void SmokeRemoveTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            testList.Remove(1);
            Assert.AreEqual(1, testList.Length);
        }

        [Test]
        public void EmptyListRemoveTest()
        {
            Assert.Throws<InvalidOperationException>(() => testList.Remove(1));
        }

        [Test]
        public void IncorrectIndexRemoveTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Remove(testList.Length));
        }

        [Test]
        public void MiddleRemoveTest()
        {
            var newString1 = "First string";
            var newString2 = "Second string";
            var newString3 = "Third string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            testList.Remove(1);
            Assert.AreEqual(newString1, testList[0]);
            Assert.AreEqual(newString3, testList[1]);
        }

        [Test]
        public void MultipleRemoveTest()
        {
            testList.InsertFirst(testFileReader.ReadLine());

            while (!testFileReader.EndOfStream)
            {
                testList.InsertAfter(testFileReader.ReadLine(), testList.Length - 1);
            }

            const int ExpectedLength = 50;

            for (var i = 0; i < ExpectedLength / 2; ++i)
            {
                testList.Remove(i);
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            testFileReader.ReadLine();

            for (var i = 0; i < ExpectedLength / 2; ++i)
            {
                Assert.AreEqual(testFileReader.ReadLine(), testList[i]);
                testFileReader.ReadLine();
            }

            Assert.AreEqual(ExpectedLength / 2, testList.Length);
        }

        [Test]
        public void SmokeExistsTest()
        {
            var newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.IsTrue(testList.Exists(newString));
        }

        [Test]
        public void NotExistsTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            Assert.IsFalse(testList.Exists(newString2));
        }

        [Test]
        public void SmokeFindPositionTest()
        {
            var newString1 = "Hello, World!!!";
            var newString2 = "Bye, World!!!";
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(1, testList.FindPosition(newString2));
        }

        [Test]
        public void EqualStringsFindPositionTest()
        {
            var newString1 = "First string";
            var newString2 = "Second string";
            var newString3 = "First string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(0, testList.FindPosition(newString3));
        }

        [Test]
        public void NotExistingStringFindPositionTest()
        {
            var newString1 = "First string";
            var newString2 = "Second string";
            var newString3 = "Third string";
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(-1, testList.FindPosition(newString3));
        }

        [Test]
        public void EmptyListFindPositionTest()
        {
            var newString = "Hello, World!!!";
            Assert.AreEqual(-1, testList.FindPosition(newString));
        }
    }
}