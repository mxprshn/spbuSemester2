using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test2.Tests
{
    [TestFixture]
    public class SortedSetTests
    {
        private SortedSet<List<string>, string> testListString;

        [SetUp]
        public void SetUp()
        {
            testListString = new SortedSet<List<string>, string>();
        }

        [TestCaseSource("TestsCasesString")]
        public void AddTestStringTest(List<string>[] lists, List<string>[] expected)
        {
            foreach (var i in lists)
            {
                testListString.Add(i);
            }

            for (var i = 0; i < expected.Length; ++i)
            {
                Assert.AreEqual(expected[i], testListString[i]);
            }
        }

        private static object[] TestsCasesString =
        {
            new object[]
            {
                new List<string>[]
                {
                    new List<string> { "1", "2", "3", "4", "5" },
                    new List<string> { "1", "2", "4", "5" },
                    new List<string> { "1", "2", "4", "5" },
                    new List<string> { "1", "2", "3", "4", "5", "6" },
                    new List<string> { "1" }
                },

                new List<string>[]
                {
                    new List<string> { "1" },
                    new List<string> { "1", "2", "4", "5" },
                    new List<string> { "1", "2", "3", "4", "5" },
                    new List<string> { "1", "2", "3", "4", "5", "6" },
                },
            }
        };
    }
}
