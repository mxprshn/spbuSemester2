using NUnit.Framework;
using System.IO;

namespace ModifiedHashTable.Tests
{
    [TestFixture(typeof(RollingHash))]
    [TestFixture(typeof(JenkinsHash))]
    [TestFixture(typeof(FNVHash))]
    public class SetTests<THashFunction> where THashFunction : IHashFunction, new()
    {
        private Set testSet;
        private StreamReader testFileReader;

        [SetUp]
        public void SetUp()
        {
            testSet = new Set(new THashFunction());
            testFileReader = new StreamReader(".\\SetTestsStrings.txt");
        }

        [TearDown]
        public void TearDown()
        {
            testFileReader.Close();
        }

        [Test]
        [TestCase("Hello, World!!!")]
        [TestCase("How razorback-jumping frogs can level six piqued gymnasts!")]
        [TestCase("")]
        public void SmokeAddTest(string input)
        {
            bool addResult;
            addResult = testSet.Add(input);
            Assert.IsTrue(addResult);
        }

        [Test]
        public void MultipleAddTest()
        {
            bool addResult;

            while (!testFileReader.EndOfStream)
            {
                addResult = testSet.Add(testFileReader.ReadLine());
                Assert.IsTrue(addResult);
            }            
        }

        [Test]
        public void EqualStringsAddTest()
        {
            bool addResult;

            testSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testSet.Add("Pack my box with five dozen liquor jugs");

            Assert.IsFalse(addResult);
        }

        [Test]
        public void AlmostEqualStringsAddTest()
        {
            bool addResult;

            testSet.Add("Pack my box with five dozen liquor jugs");
            addResult = testSet.Add("pack my box with five dozen liquor jugs");

            Assert.IsTrue(addResult);
        }

        [Test]
        public void SmokeRemoveTest()
        {
            bool removeResult;
            var testString = "Hello, World!!!";
            testSet.Add(testString);
            removeResult = testSet.Remove(testString);
            Assert.IsTrue(removeResult);
        }

        [Test]
        public void MultipleRemoveTest()
        {
            bool removeResult;

            while (!testFileReader.EndOfStream)
            {
                testSet.Add(testFileReader.ReadLine());
            }

            testFileReader.DiscardBufferedData();
            testFileReader.BaseStream.Seek(0, SeekOrigin.Begin);

            while (!testFileReader.EndOfStream)
            {
                removeResult = testSet.Remove(testFileReader.ReadLine());
                Assert.IsTrue(removeResult);
            }            
        }

        [Test]
        public void NotExistingStringRemoveTest()
        {
            bool removeResult = true;
            removeResult = testSet.Remove("Goodbye, world!!!");
            Assert.IsFalse(removeResult);
        }

        [Test]
        public void SmokeExistsRollingHashTest()
        {
            bool exists;
            var testString = "Hello, World!!!";
            testSet.Add(testString);
            exists = testSet.Exists(testString);
            Assert.IsTrue(exists);
        }

        [Test]
        public void NotExistsRollingHashTest()
        {
            bool exists = true;
            exists = testSet.Exists("Good evening, world!!!");
            Assert.IsFalse(exists);
        }
    }
}