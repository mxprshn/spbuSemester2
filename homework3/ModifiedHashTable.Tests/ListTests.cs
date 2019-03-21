using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SinglyLinkedList.Tests
{
    [TestClass()]
    public class ListTests
    {
        private List testList;
        private StreamReader testFileReader;

        [TestInitialize]
        public void Initialize()
        {
            testList = new List();
            testFileReader = new StreamReader("..\\..\\ListTestsStrings.txt");
        }

        [TestCleanup]
        public void CleanUp()
        {
            testFileReader.Close();
        }

        [TestMethod()]
        public void SmokeInsertFirstTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.AreEqual(newString, testList[0]);
            Assert.AreEqual(1, testList.Length);
        }

        [TestMethod()]
        public void EqualStringsInsertFirstTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            testList.InsertFirst(newString);
            Assert.AreEqual(newString, testList[1]);
            Assert.AreEqual(newString, testList[0]);
            Assert.AreEqual(2, testList.Length);
        }

        [TestMethod()]
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

        [TestMethod()]
        public void SmokeInsertAfterTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertAfter(newString2, 0);
            Assert.AreEqual(newString2, testList[1]);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyListInsertAfterTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertAfter(newString, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IncorrectIndexInsertAfterTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertAfter(newString2, -11);
        }

        [TestMethod()]
        public void MiddleInsertAfterTest()
        {
            string newString1 = "First string";
            string newString2 = "Second string";
            string newString3 = "Third string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString1);
            testList.InsertAfter(newString2, 0);
            Assert.AreEqual(newString2, testList[1]);
        }

        [TestMethod()]
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

        [TestMethod()]
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

        [TestMethod()]
        public void SmokeRemoveFirstTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            testList.RemoveFirst();
            Assert.AreEqual(newString1, testList[0]);
            Assert.AreEqual(1, testList.Length);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyListRemoveFirstTest()
        {
            testList.RemoveFirst();
        }

        [TestMethod()]
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

        [TestMethod()]
        public void SmokeRemoveTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            testList.Remove(1);
            Assert.AreEqual(1, testList.Length);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyListRemoveTest()
        {
            testList.Remove(1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IncorrectIndexRemoveTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            testList.InsertFirst(newString2);
            testList.Remove(testList.Length);
        }

        [TestMethod()]
        public void MiddleRemoveTest()
        {
            string newString1 = "First string";
            string newString2 = "Second string";
            string newString3 = "Third string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            testList.Remove(1);
            Assert.AreEqual(newString1, testList[0]);
            Assert.AreEqual(newString3, testList[1]);
        }

        [TestMethod()]
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

        [TestMethod()]
        public void SmokeExistsTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            Assert.IsTrue(testList.Exists(newString));
        }

        [TestMethod()]
        public void NotExistsTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString1);
            Assert.IsFalse(testList.Exists(newString2));
        }

        [TestMethod()]
        public void SmokeFindPositionTest()
        {
            string newString1 = "Hello, World!!!";
            string newString2 = "Bye, World!!!";
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(1, testList.FindPosition(newString2));
        }

        [TestMethod()]
        public void EqualStringsFindPositionTest()
        {
            string newString1 = "First string";
            string newString2 = "Second string";
            string newString3 = "First string";
            testList.InsertFirst(newString3);
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(0, testList.FindPosition(newString3));
        }

        [TestMethod()]
        public void NotExistingStringFindPositionTest()
        {
            string newString1 = "First string";
            string newString2 = "Second string";
            string newString3 = "Third string";
            testList.InsertFirst(newString2);
            testList.InsertFirst(newString1);
            Assert.AreEqual(-1, testList.FindPosition(newString3));
        }

        [TestMethod()]
        public void EmptyListFindPositionTest()
        {
            string newString = "Hello, World!!!";
            Assert.AreEqual(-1, testList.FindPosition(newString));
        }
    }
}