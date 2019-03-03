using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModifiedHashTable;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedHashTable.Tests
{
    [TestClass()]
    public class SetTests
    {
        private Set testRollingHashSet;
        private Set testJenkinsHashSet;
        private Set testFNVHashSet;
        private FileStream testFile;
        private StreamReader testFileReader;

        [TestInitialize]
        public void Initialize()
        {
            testRollingHashSet = new Set(new RollingHash());
            testJenkinsHashSet = new Set(new JenkinsHash());
            testFNVHashSet = new Set(new FNVHash());
            testFile = new FileStream("..\\..\\SetTestsStrings.txt", FileMode.Open, FileAccess.Read);
            testFileReader = new StreamReader(testFile);
        }

        [TestCleanup]
        public void CleanUp()
        {
            testFileReader.Close();
        }

        [TestMethod()]
        public void SmokeAddRollingHashTest()
        {
            bool addResult = false;
            addResult = testRollingHashSet.Add("Hello, World!!!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void SmokeAddJenkinsHashTest()
        {
            bool addResult = false;
            addResult = testJenkinsHashSet.Add("Hello, World!!!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void SmokeAddFNVHashTest()
        {
            bool addResult = false;
            addResult = testFNVHashSet.Add("Hello, World!!!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void LongStringAddRollingHashTest()
        {
            bool addResult = false;
            addResult = testRollingHashSet.Add("How razorback-jumping frogs " +
                "can level six piqued gymnasts!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void LongStringAddJenkinsHashTest()
        {
            bool addResult = false;
            addResult = testJenkinsHashSet.Add("How razorback-jumping frogs " +
                "can level six piqued gymnasts!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void LongStringAddFNVHashTest()
        {
            bool addResult = false;
            addResult = testFNVHashSet.Add("How razorback-jumping frogs " +
                "can level six piqued gymnasts!");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void EmptyStringAddRollingHashTest()
        {
            bool addResult = false;
            addResult = testRollingHashSet.Add("");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void EmptyStringAddJenkinsHashTest()
        {
            bool addResult = false;
            addResult = testJenkinsHashSet.Add("");
            Assert.IsTrue(addResult);
        }

        [TestMethod()]
        public void EmptyStringAddFNVHashTest()
        {
            bool addResult = false;
            addResult = testFNVHashSet.Add("");
            Assert.IsTrue(addResult);
        }

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
        public void RemoveTest()
        {
            
        }

        [TestMethod()]
        public void ExistsTest()
        {
            
        }
    }
}