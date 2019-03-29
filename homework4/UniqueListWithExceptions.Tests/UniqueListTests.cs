using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UniqueListWithExceptions.Tests
{
    [TestClass()]
    public class UniqueListTests
    {
        private UniqueList testList;
        private StreamReader testFileReader;

        [TestInitialize]
        public void Initialize()
        {
            testList = new UniqueList();
            testFileReader = new StreamReader("..\\..\\UniqueListTestsStrings.txt");
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
        [ExpectedException(typeof(ExistingElementInsertionException))]
        public void EqualStringsInsertFirstTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            testList.InsertFirst(newString);
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
        [ExpectedException(typeof(ExistingElementInsertionException))]
        public void EqualStringsInsertAfterTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertFirst(newString);
            testList.InsertAfter(newString, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyListOperationException))]
        public void EmptyListInsertAfterTest()
        {
            string newString = "Hello, World!!!";
            testList.InsertAfter(newString, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(IncorrectIndexException))]
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
    }
}