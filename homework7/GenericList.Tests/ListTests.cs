using System;
using System.Linq;
using NUnit.Framework;

namespace GenericList.Tests
{
    [TestFixture]
    public class ListTests
    {
        private List<int> testList;

        public interface IAddTester
        {
            void AddTest();
        }

        private class AddTester<T> : IAddTester
        {
            private List<T> testList = new List<T>();
            private T[] valuesToAdd;

            public AddTester(T[] valuesToAdd)
            {
                this.valuesToAdd = valuesToAdd;
            }

            public void AddTest()
            {
                foreach (var current in valuesToAdd)
                {
                    testList.Add(current);
                }

                Assert.AreEqual(valuesToAdd.Length, testList.Count);
                Assert.IsTrue(testList.SequenceEqual(valuesToAdd));
            }
        }

        [SetUp]
        public void SetUp() => testList = new List<int>();

        [TestCaseSource("AddTestCases")]
        public void AddTest(IAddTester tester) => tester.AddTest();

        [TestCaseSource("InsertTestCases")]
        public void InsertTest(int[] valuesToAdd, (int, int)[] targetValues, int[] expectedValues)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            foreach (var current in targetValues)
            {
                testList.Insert(current.Item1, current.Item2);              
            }

            Assert.AreEqual(expectedValues.Length, testList.Count);
            Assert.IsTrue(testList.SequenceEqual(expectedValues));
        }

        [Test]
        public void InsertAtInvalidPositionTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.Insert(4, 4));
        }

        [TestCaseSource("RemoveAtTestCases")]
        public void RemoveAtTest(int[] valuesToAdd, int[] targetPositions, int[] expectedValues)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            foreach (var current in targetPositions)
            {
                testList.RemoveAt(current);
            }

            Assert.AreEqual(expectedValues.Length, testList.Count);
            Assert.IsTrue(testList.SequenceEqual(expectedValues));
        }

        [Test]
        public void RemoveFromInvalidPositionTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.RemoveAt(4));
        }

        [TestCaseSource("RemoveTestCases")]
        public void RemoveTest(int[] valuesToAdd, (int, bool)[] valuesToRemove, int[] expectedValues)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            foreach (var current in valuesToRemove)
            {
                Assert.AreEqual(current.Item2, testList.Remove(current.Item1));
            }

            Assert.AreEqual(expectedValues.Length, testList.Count);
            Assert.IsTrue(testList.SequenceEqual(expectedValues));
        }

        [TestCaseSource("ContainsTestCases")]
        public void ContainsTest(int[] valuesToAdd, int valueToCheck, bool expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            Assert.AreEqual(expectedResult, testList.Contains(valueToCheck));
        }

        [TestCaseSource("IndexOfTestCases")]
        public void IndexOfTest(int[] valuesToAdd, int valueToCheck, int expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            Assert.AreEqual(expectedResult, testList.IndexOf(valueToCheck));
        }

        [Test]
        public void IndexerGetTest()
        {
            int[] valuesToAdd = { 1, 2, 3, 4, 5 };

            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            for (var i = 0; i < valuesToAdd.Length; ++i)
            {
                Assert.AreEqual(valuesToAdd[i], testList[i]);
            }
        }

        [Test]
        public void IndexerSetTest()
        {
            int[] valuesToAdd = { 1, 2, 3, 4, 5 };
            int[] newValues = { 10, 20, 30, 40, 50 };

            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            for (var i = 0; i < newValues.Length; ++i)
            {
                testList[i] = newValues[i];
            }

            for (var i = 0; i < newValues.Length; ++i)
            {
                Assert.AreEqual(newValues[i], testList[i]);
            }
        }

        [TestCaseSource("CopyToTestCases")]
        public void CopyToTest(int[] valuesToAdd, int[] targetArray, int targetIndex, int[] expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testList.Add(current);
            }

            testList.CopyTo(targetArray, targetIndex);

            Assert.IsTrue(targetArray.SequenceEqual(expectedResult));
        }

        [Test]
        public void CopyToNullTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            int[] target = null;
            Assert.Throws<ArgumentNullException>(() => testList.CopyTo(target, 2));
        }

        [Test]
        public void CopyToNegativePositionTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            int[] target = { 1, 2, 3, 4, 5,};
            Assert.Throws<ArgumentOutOfRangeException>(() => testList.CopyTo(target, -2));
        }

        [Test]
        public void CopyToShortArrayTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            int[] target = { 1, 2, 3, 4, 5 };
            Assert.Throws<ArgumentException>(() => testList.CopyTo(target, 3));
        }

        [Test]
        public void ClearTest()
        {
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Clear();
            Assert.AreEqual(0, testList.Count);
        }

        private static object[] AddTestCases =
        {
            new AddTester<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
            new AddTester<int>(new int[] { 2048 }),
            new AddTester<int>(new int[] { 0, 0, 0, 0, 0 }),
            new AddTester<char>(new char[] { 'a', 'b', 'c', 'd', '@' }),
            new AddTester<bool>(new bool[] { true, true, true }),
            new AddTester<string>(new string[] { "january", "february", "march", "april" }),
            new AddTester<IAddTester>(new IAddTester[] { new AddTester<int>(new int[] { 2048 }),
                    new AddTester<bool>(new bool[] { true, true, true }) })
        };

        private static object[] InsertTestCases =
        {
            new object[] { new int[] { 10, 20, 30, 40, 50 }, new (int, int)[] { (2, 25), (5, 45) },
                    new int[] { 10, 20, 25, 30, 40, 45, 50 } },
            new object[] { new int[] { 10, 20, 30, 40, 50 }, new (int, int)[] { (0, 5) },
                    new int[] { 5, 10, 20, 30, 40, 50 } },
            new object[] { new int[] { 0 }, new (int, int)[] { (0, 10), (1, 20), (2, 10), (3, 20) },
                    new int[] { 10, 20, 10, 20, 0 } },
            new object[] { new int[] { 0 }, new (int, int)[] { (0, 10), (0, 20), (0, 10), (0, 20) },
                    new int[] { 20, 10, 20, 10, 0 } },
            new object[] { new int[] { }, new (int, int)[] { (0, 10), (0, 20), (0, 30), (0, 40) },
                    new int[] { 40, 30, 20, 10 } }
        };

        private static object[] RemoveAtTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 2 }, new int[] { 1, 2, 4, 5 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 0 }, new int[] { 2, 3, 4, 5 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 4 }, new int[] { 1, 2, 3, 4 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 2, 1, 0 }, new int[] { } },
            new object[] { new int[] { 2048 }, new int[] { 0 }, new int[] { } },
        };

        private static object[] RemoveTestCases =
        {
            new object[] { new int[] { -1, -2, 0, 2, 1 }, new (int, bool)[] { (0, true), (0, false) },
                    new int[] { -1, -2, 2, 1 } },
            new object[] { new int[] { -1, -2, 0, 2, 1 }, new (int, bool)[] { (0, true), (1, true),
                    (-1, true), (-2, true), (2, true) }, new int[] { } },
            new object[] { new int[] { 1, 2, 0, 2, 1 }, new (int, bool)[] { (1, true) },
                    new int[] { 2, 0, 2, 1 } },
            new object[] { new int[] { 1, 2, 0, 2, 1 }, new (int, bool)[] { (1, true), (1, true), (1, false) },
                    new int[] { 2, 0, 2 } }
        };

        private static object[] ContainsTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, 1, true },
            new object[] { new int[] { }, 1, false },
            new object[] { new int[] { 0, 0, 0, 0, 0 }, 0, true }
        };

        private static object[] IndexOfTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, 3, 2 },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, 10, -1 },
            new object[] { new int[] { }, 1, -1 },
            new object[] { new int[] { 0, 0, 0, 0, 0 }, 0, 0 }
        };

        private static object[] CopyToTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new int[] { 0, 0, 0, 0, 0 }, 1,
                    new int[] { 0, 1, 2, 3, 0 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0 }, 0,
                    new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] { 2048 }, new int[] { 0 }, 0, new int[] { 2048 } },
            new object[] { new int[] { }, new int[] { 0 }, 0, new int[] { 0 } },
        };
    }
}