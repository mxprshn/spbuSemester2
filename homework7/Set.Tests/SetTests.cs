using System;
using GenericSet;
using NUnit.Framework;

namespace Set.Tests
{
    [TestFixture]
    public class SetTests
    {
        private Set<int> testSet;

        [SetUp]
        public void SetUp()
        {
            testSet = new Set<int>();
        }

        [TestCaseSource("RemoveTestCases")]
        public void RemoveTest(int[] valuesToAdd, int[] valuesToRemove)
        {
            foreach (var current in valuesToAdd)
            {
                testSet.Add(current);
            }

            foreach (var current in valuesToRemove)
            {
                Assert.IsTrue(testSet.Remove(current));
                Assert.IsFalse(testSet.Contains(current));
            }

            Assert.AreEqual(0, testSet.Count);
        }

        private static object[] RemoveTestCases =
        {
            new object[]
            {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 5, 4, 3, 2, 1 }
            },

            new object[]
            {
                new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 },
                new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }
            }
        };



    }
}
