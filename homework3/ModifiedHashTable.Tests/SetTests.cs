using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ModifiedHashTable.Tests
{
    [TestClass()]
    public class SetTests
    {
        private Set testRollingHashSet;
        private Set testJenkinsHashSet;
        private Set testFNVHashSet;
        private StreamReader testFileReader;

        [TestInitialize]
        public void Initialize()
        {
            testRollingHashSet = new Set(new RollingHash());
            testJenkinsHashSet = new Set(new JenkinsHash());
            testFNVHashSet = new Set(new FNVHash());
            testFileReader = new StreamReader("..\\..\\SetTestsStrings.txt");
        }

        [TestCleanup]
        public void CleanUp()
        {
            testFileReader.Close();
        }

        [TestMethod()]
        [DataRow("Hello, World!!!")]
        [DataRow("How razorback-jumping frogs can level six piqued gymnasts!")]
        [DataRow("")]
        public void SmokeAddRollingHashTest(string input)
        {
            bool addResult;
            addResult = testRollingHashSet.Add(input);
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        [DataRow("Hello, World!!!")]
        [DataRow("How razorback-jumping frogs can level six piqued gymnasts!")]
        [DataRow("")]
        public void SmokeAddJenkinsHashTest(string input)
        {
            bool addResult;
            addResult = testJenkinsHashSet.Add(input);
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        [DataRow("Hello, World!!!")]
        [DataRow("How razorback-jumping frogs can level six piqued gymnasts!")]
        [DataRow("")]
        public void SmokeAddFNVHashTest(string input)
        {
            bool addResult;
            addResult = testFNVHashSet.Add(input);
            Assert.IsTrue(addResult);
        }

        //[TestMethod()]
        //public void SmokeAddRollingHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testRollingHashSet.Add("Hello, World!!!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void SmokeAddJenkinsHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testJenkinsHashSet.Add("Hello, World!!!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void SmokeAddFNVHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testFNVHashSet.Add("Hello, World!!!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void LongStringAddRollingHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testRollingHashSet.Add("How razorback-jumping frogs " +
        //        "can level six piqued gymnasts!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void LongStringAddJenkinsHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testJenkinsHashSet.Add("How razorback-jumping frogs " +
        //        "can level six piqued gymnasts!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void LongStringAddFNVHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testFNVHashSet.Add("How razorback-jumping frogs " +
        //        "can level six piqued gymnasts!");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void EmptyStringAddRollingHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testRollingHashSet.Add("");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void EmptyStringAddJenkinsHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testJenkinsHashSet.Add("");
        //    Assert.IsTrue(addResult);
        //}

        //[TestMethod()]
        //public void EmptyStringAddFNVHashTest()
        //{
        //    bool addResult = false;
        //    addResult = testFNVHashSet.Add("");
        //    Assert.IsTrue(addResult);
        //}

        [TestMethod()]
        public void MultipleAddRollingHashTest()
        {
            bool addResult = true;

            while (!testFileReader.EndOfStream && addResult)
            {
                addResult = testRollingHashSet.Add(testFileReader.ReadLine());                
            }

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void MultipleAddJenkinsHashTest()
        {
            bool addResult = true;

            while (!testFileReader.EndOfStream && addResult)
            {
                addResult = testJenkinsHashSet.Add(testFileReader.ReadLine());
            }

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void MultipleAddFNVHashTest()
        {
            bool addResult = true;

            while (!testFileReader.EndOfStream && addResult)
            {
                addResult = testFNVHashSet.Add(testFileReader.ReadLine());
            }

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void EqualStringsAddRollingHashTest()
        {
            bool addResult = false;

            addResult = testRollingHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testRollingHashSet.Add("Pack my box with five dozen liquor jugs");

            Assert.IsFalse(addResult);
        }

        [TestMethod()]
        public void EqualStringsAddJenkinsHashTest()
        {
            bool addResult = false;

            addResult = testJenkinsHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testJenkinsHashSet.Add("Pack my box with five dozen liquor jugs");

            Assert.IsFalse(addResult);
        }

        [TestMethod()]
        public void EqualStringsAddFNVHashTest()
        {
            bool addResult = false;

            addResult = testFNVHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testFNVHashSet.Add("Pack my box with five dozen liquor jugs");

            Assert.IsFalse(addResult);
        }

        [TestMethod()]
        public void AlmostEqualStringsAddRollingHashTest()
        {
            bool addResult = false;

            addResult = testRollingHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testRollingHashSet.Add("pack my box with five dozen liquor jugs");

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void AlmostEqualStringsAddJenkinsHashTest()
        {
            bool addResult = false;

            addResult = testJenkinsHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testJenkinsHashSet.Add("pack my box with five dozen liquor jugs");

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void AlmostEqualStringsAddFNVHashTest()
        {
            bool addResult = false;

            addResult = testFNVHashSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testFNVHashSet.Add("pack my box with five dozen liquor jugs");

            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void SmokeRemoveRollingHashTest()
        {
            bool removeResult = false;
            string testString = "Hello, World!!!";
            testRollingHashSet.Add(testString);
            removeResult = testRollingHashSet.Remove(testString);
            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void SmokeRemoveJenkinsHashTest()
        {
            bool removeResult = false;
            string testString = "Hello, World!!!";
            testJenkinsHashSet.Add(testString);
            removeResult = testJenkinsHashSet.Remove(testString);
            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void SmokeRemoveFNVHashTest()
        {
            bool removeResult = false;
            string testString = "Hello, World!!!";
            testFNVHashSet.Add(testString);
            removeResult = testFNVHashSet.Remove(testString);
            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void MultipleRemoveRollingHashTest()
        {
            bool removeResult = true;

            while (!testFileReader.EndOfStream)
            {
                testRollingHashSet.Add(testFileReader.ReadLine());
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (!testFileReader.EndOfStream && removeResult)
            {
                removeResult = testRollingHashSet.Remove(testFileReader.ReadLine());
            }

            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void MultipleRemoveJenkinsHashTest()
        {
            bool removeResult = true;

            while (!testFileReader.EndOfStream)
            {
                testJenkinsHashSet.Add(testFileReader.ReadLine());
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (!testFileReader.EndOfStream && removeResult)
            {
                removeResult = testJenkinsHashSet.Remove(testFileReader.ReadLine());
            }

            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void MultipleRemoveFNVHashTest()
        {
            bool removeResult = true;

            while (!testFileReader.EndOfStream)
            {
                testFNVHashSet.Add(testFileReader.ReadLine());
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (!testFileReader.EndOfStream && removeResult)
            {
                removeResult = testFNVHashSet.Remove(testFileReader.ReadLine());
            }

            Assert.IsTrue(removeResult);
        }

        [TestMethod()]
        public void NotExistingStringRemoveRollingHashTest()
        {
            bool removeResult = true;
            removeResult = testRollingHashSet.Remove("Goodbye, world!!!");
            Assert.IsFalse(removeResult);
        }

        [TestMethod()]
        public void NotExistingStringRemoveJenkinsHashTest()
        {
            bool removeResult = true;
            removeResult = testJenkinsHashSet.Remove("Goodbye, world!!!");
            Assert.IsFalse(removeResult);
        }

        [TestMethod()]
        public void NotExistingStringRemoveFNVHashTest()
        {
            bool removeResult = true;
            removeResult = testFNVHashSet.Remove("Goodbye, world!!!");
            Assert.IsFalse(removeResult);
        }

        [TestMethod()]
        public void SmokeExistsRollingHashTest()
        {
            bool exists = false;
            string testString = "Hello, World!!!";
            testRollingHashSet.Add(testString);
            exists = testRollingHashSet.Exists(testString);
            Assert.IsTrue(exists);
        }

        [TestMethod()]
        public void SmokeExistsJenkinsHashTest()
        {
            bool exists = false;
            string testString = "Hello, World!!!";
            testJenkinsHashSet.Add(testString);
            exists = testJenkinsHashSet.Exists(testString);
            Assert.IsTrue(exists);
        }

        [TestMethod()]
        public void SmokeExistsFNVHashTest()
        {
            bool exists = false;
            string testString = "Hello, World!!!";
            testFNVHashSet.Add(testString);
            exists = testFNVHashSet.Exists(testString);
            Assert.IsTrue(exists);
        }

        [TestMethod()]
        public void NotExistsRollingHashTest()
        {
            bool exists = true;
            exists = testRollingHashSet.Exists("Good evening, world!!!");
            Assert.IsFalse(exists);
        }

        [TestMethod()]
        public void NotExistsJenkinsHashTest()
        {
            bool exists = true;
            exists = testJenkinsHashSet.Exists("Good evening, world!!!");
            Assert.IsFalse(exists);
        }

        [TestMethod()]
        public void NotExistsFNVHashTest()
        {
            bool exists = true;
            exists = testFNVHashSet.Exists("Good evening, world!!!");
            Assert.IsFalse(exists);
        }
    }
}