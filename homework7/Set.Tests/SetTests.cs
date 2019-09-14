using System;
using GenericSet;
using System.Collections.Generic;
using NUnit.Framework;

namespace Set.Tests
{
    [TestFixture]
    public class SetTests
    {
        private Set<int> testIntSet;

        public interface ICollectionTester
        {
            void AddTest();
            void ClearTest();
            void RemoveTest();
            void EnumeratorTest();
        }

        [SetUp]
        public void SetUp() => testIntSet = new Set<int>();

        private class CollectionTester<T> : ICollectionTester where T : IComparable<T>
        {
            private Set<T> testSet = new Set<T>();
            private T[] valuesToAdd;
            private T[] valuesToRemove;
            private int expectedAmount;

            public CollectionTester(T[] valuesToAdd, int expectedAmount, T[] valuesToRemove = null)
            {
                this.valuesToAdd = valuesToAdd;
                this.valuesToRemove = valuesToRemove;
                this.expectedAmount = expectedAmount;
            }

            public void AddTest()
            {
                foreach (var current in valuesToAdd)
                {
                    var contains = testSet.Contains(current);
                    var wasAdded = testSet.Add(current);
                    Assert.IsTrue(contains ^ wasAdded);
                    Assert.IsTrue(testSet.Contains(current));
                }

                Assert.AreEqual(expectedAmount, testSet.Count);
            }

            public void ClearTest()
            {
                foreach (var current in valuesToAdd)
                {
                    _ = testSet.Add(current);
                }

                testSet.Clear();
                Assert.AreEqual(0, testSet.Count);
            }

            public void RemoveTest()
            {
                foreach (var current in valuesToAdd)
                {
                    _ = testSet.Add(current);
                }

                foreach (var current in valuesToRemove)
                {
                    var contains = testSet.Contains(current);
                    var wasRemoved = testSet.Remove(current);
                    Assert.IsFalse(contains ^ wasRemoved);
                }

                Assert.AreEqual(expectedAmount, testSet.Count);
            }

            public void EnumeratorTest()
            {
                foreach (var current in valuesToAdd)
                {
                    _ = testSet.Add(current);
                }

                T previous = default;
                var isFirst = true;

                foreach (var current in testSet)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        Assert.IsTrue(previous.CompareTo(current) < 0);
                    }

                    previous = current;
                }
            }
        }

        [TestCaseSource("CopyToTestCases")]
        public void CopyToTest(int[] valuesToAdd, int[] destination, int position)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            testIntSet.CopyTo(destination, position);

            for (var i = position; i < position + valuesToAdd.Length; ++i)
            {
                Assert.IsTrue(testIntSet.Contains(destination[i]));
            }
        }

        [Test]
        public void CopyToNullTest()
        {
            int[] nullArray = null;
            var valuesToAdd = new int[] { 1, 2, 3 };

            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            Assert.Throws<ArgumentNullException>(() => testIntSet.CopyTo(nullArray, 2));
        }

        [Test]
        public void CopyToNegativePositionTest()
        {
            var destination = new int[] { 1, 2, 3, 4, 5 };
            var valuesToAdd = new int[] { 1, 2, 3 };

            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => testIntSet.CopyTo(destination, -5));
        }

        [Test]
        public void CopyToShortArrayTest()
        {
            var destination = new int[] { -4, -3, -2, -1, 0 };
            var valuesToAdd = new int[] { 1, 2, 3 };

            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            Assert.Throws<ArgumentException>(() => testIntSet.CopyTo(destination, 3));
        }

        [TestCaseSource("UnionWithTestCases")]
        public void UnionWithTest(int[] valuesToAdd, List<int> other, int[] expectedResult)
        {
            foreach(var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.UnionWith(other));
            }
            else
            {
                testIntSet.UnionWith(other);
                Assert.AreEqual(expectedResult.Length, testIntSet.Count);

                foreach (var current in expectedResult)
                {
                    Assert.IsTrue(testIntSet.Contains(current));
                }
            }
        }

        [TestCaseSource("IntersectWithTestCases")]
        public void IntersectWithTest(int[] valuesToAdd, List<int> other, int[] expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.IntersectWith(other));
            }
            else
            {
                testIntSet.IntersectWith(other);
                Assert.AreEqual(expectedResult.Length, testIntSet.Count);

                foreach (var current in expectedResult)
                {
                    Assert.IsTrue(testIntSet.Contains(current));
                }
            }
        }

        [TestCaseSource("ExceptWithTestCases")]
        public void ExceptWithTest(int[] valuesToAdd, List<int> other, int[] expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.ExceptWith(other));
            }
            else
            {
                testIntSet.ExceptWith(other);
                Assert.AreEqual(expectedResult.Length, testIntSet.Count);

                foreach (var current in expectedResult)
                {
                    Assert.IsTrue(testIntSet.Contains(current));
                }
            }
        }

        [TestCaseSource("SymmetricExceptWithTestCases")]
        public void SymmetricExceptWithTest(int[] valuesToAdd, List<int> other, int[] expectedResult)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.SymmetricExceptWith(other));
            }
            else
            {
                testIntSet.SymmetricExceptWith(other);
                Assert.AreEqual(expectedResult.Length, testIntSet.Count);

                foreach (var current in expectedResult)
                {
                    Assert.IsTrue(testIntSet.Contains(current));
                }
            }
        }

        [TestCaseSource("IsSubsetOfTestCases")]
        public void IsSubsetOfTest(int[] valuesToAdd, List<int> other, bool isSubsetOf)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.IsSubsetOf(other));
            }
            else
            {
                Assert.IsFalse(isSubsetOf ^ testIntSet.IsSubsetOf(other));
            }
        }

        [TestCaseSource("IsSupersetOfTestCases")]
        public void IsSupersetOfTest(int[] valuesToAdd, List<int> other, bool isSupersetOf)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.IsSupersetOf(other));
            }
            else
            {
                Assert.IsFalse(isSupersetOf ^ testIntSet.IsSupersetOf(other));
            }
        }

        [TestCaseSource("IsProperSupersetOfTestCases")]
        public void IsProperSupersetOfTest(int[] valuesToAdd, List<int> other, bool isProperSupersetOf)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.IsProperSupersetOf(other));
            }
            else
            {
                Assert.IsFalse(isProperSupersetOf ^ testIntSet.IsProperSupersetOf(other));
            }
        }

        [TestCaseSource("IsProperSubsetOfTestCases")]
        public void IsProperSubsetOfTest(int[] valuesToAdd, List<int> other, bool isProperSubsetOf)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.IsProperSubsetOf(other));
            }
            else
            {
                Assert.IsFalse(isProperSubsetOf ^ testIntSet.IsProperSubsetOf(other));
            }
        }

        [TestCaseSource("SetEqualsTestCases")]
        public void SetEqualsTest(int[] valuesToAdd, List<int> other, bool setEquals)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.SetEquals(other));
            }
            else
            {
                Assert.IsFalse(setEquals ^ testIntSet.SetEquals(other));
            }
        }

        [TestCaseSource("OverlapsTestCases")]
        public void OverlapsTest(int[] valuesToAdd, List<int> other, bool overlaps)
        {
            foreach (var current in valuesToAdd)
            {
                testIntSet.Add(current);
            }

            if (other == null)
            {
                Assert.Throws<ArgumentNullException>(() => testIntSet.Overlaps(other));
            }
            else
            {
                Assert.IsFalse(overlaps ^ testIntSet.Overlaps(other));
            }
        }

        [TestCaseSource("TestCases")]
        public void AddTest(ICollectionTester tester) => tester.AddTest();

        [TestCaseSource("RemoveTestCases")]
        public void RemoveTest(ICollectionTester tester) => tester.RemoveTest();

        [TestCaseSource("TestCases")]
        public void ClearTest(ICollectionTester tester) => tester.ClearTest();

        [TestCaseSource("TestCases")]
        public void EnumeratorTest(ICollectionTester tester) => tester.EnumeratorTest();

        private static object[] CopyToTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new int[] { 0, 0, 0, 0, 0 }, 1 },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0 }, 0 },
            new object[] { new int[] { 2048 }, new int[] { 0 }, 0 }
        };

        private static object[] TestCases =
        {
            new CollectionTester<int>(new int[] { 1, 2, 3, 4, 5 }, 5),
            new CollectionTester<int>(new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }, 11),
            new CollectionTester<int>(new int[] { 0, 4, -4, 3, -3, 2, -2, -1, 1, 5, -5 }, 11),
            new CollectionTester<int>(new int[] { 1, 1, 1, 1, 1 }, 1),
            new CollectionTester<int>(new int[] { 1, 2, 1, 2, 1 }, 2),
            new CollectionTester<string>(new string[] { "hello", "world", "Hello", "World", "" }, 5),
            new CollectionTester<string>(new string[] { "January", "February", "March", "February", "January" }, 3),
            new CollectionTester<bool>(new bool[] { true, false, true, false, false }, 2)
        };

        private static object[] RemoveTestCases =
        {
            new CollectionTester<int>(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 3 }),
            new CollectionTester<int>(new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }, 10, new int[] { 0 }),
            new CollectionTester<int>(new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }, 0,
                    new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }),
            new CollectionTester<int>(new int[] { 0, 4, -4, 3, -3, 2, -2, -1, 1, 5, -5 }, 10, new int[] { -5 }),
            new CollectionTester<int>(new int[] { 0, 4, -4, 3, -3, 2, -2, -1, 1, 5, -5 }, 9,
                    new int[] { 4, -4 }),
            new CollectionTester<int>(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 2048 }),
            new CollectionTester<string>(new string[] { "M", "D", "R", "B", "U", "F", "P" }, 0,
                    new string[] { "M", "P", "R", "U", "D", "F", "B" })
        };

        private static object[] UnionWithTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } },
            new object[] { new int[] { 2, -1024, 64, 128, -256 }, new List<int> { 4, 2, -1024, 512, 128, -2048 },
                    new int[] { 2, 4, 64, 128, 512, -2048, -1024, -256 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 5, 1, 4, 3, 3 },
                    new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] { }, new List<int> { 1, 5, 1, 4, 3, 3, 2 },
                    new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] { 1 }, new List<int> { },
                    new int[] { 1 } },
            new object[] { new int[] { 1, 2, 3 }, null, null }
        };

        private static object[] IntersectWithTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 },
                    new int[] { } },
            new object[] { new int[] { 2, -1024, 64, 128, -256 }, new List<int> { 4, 2, -1024, 512, 128, -2048 },
                    new int[] { 2, -1024, 128 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 5, 1, 4, 3, 3 },
                    new int[] { 1, 3, 4, 5 } },
            new object[] { new int[] { }, new List<int> { 1, 5, 1, 4, 3, 3, 2 },
                    new int[] { } },
            new object[] { new int[] { 1 }, new List<int> { },
                    new int[] { } },
            new object[] { new int[] { 1, 2, 3 }, null, null }
        };

        private static object[] ExceptWithTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 },
                    new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] { 2, -1024, 64, 128, -256 }, new List<int> { 4, 2, -1024, 512, 128, -2048 },
                    new int[] { 64, -256 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 5, 1, 4, 3, 3 },
                    new int[] { 2 } },
            new object[] { new int[] { }, new List<int> { 1, 5, 1, 4, 3, 3, 2 },
                    new int[] { } },
            new object[] { new int[] { 1 }, new List<int> { },
                    new int[] { 1 } },
            new object[] { new int[] { 1, 2, 3 }, null, null }
        };

        private static object[] SymmetricExceptWithTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } },
            new object[] { new int[] { 2, -1024, 64, 128, -256 }, new List<int> { 4, 2, -1024, 512, 128, -2048 },
                    new int[] { 64, -256, 4, -2048, 512 } },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 5, 1, 4, 3, 3 },
                    new int[] { 2 } },
            new object[] { new int[] { }, new List<int> { 1, 5, 1, 4, 3, 3, 2 },
                    new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] { 1 }, new List<int> { },
                    new int[] { 1 } },
            new object[] { new int[] { 1, 2, 3 }, null, null }
        };

        private static object[] IsSubsetOfTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 }, false },
            new object[] { new int[] { }, new List<int> { 1 }, true },
            new object[] { new int[] { 1 }, new List<int> { }, false },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };

        private static object[] IsSupersetOfTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 }, false },
            new object[] { new int[] { }, new List<int> { 1 }, false },
            new object[] { new int[] { 1 }, new List<int> { }, true },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };

        private static object[] IsProperSupersetOfTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 }, false },
            new object[] { new int[] { }, new List<int> { 1 }, false },
            new object[] { new int[] { 1 }, new List<int> { }, true },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };

        private static object[] IsProperSubsetOfTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3 }, false },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 }, false },
            new object[] { new int[] { }, new List<int> { 1 }, true },
            new object[] { new int[] { 1 }, new List<int> { }, false },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };

        private static object[] SetEqualsTestCases =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 1, 2, 3, 1, 3, 2 }, true },
            new object[] { new int[] { 0, 1, 2, 3 }, new List<int> { 1, 2, 3 }, false },
            new object[] { new int[] { 1 }, new List<int> { 1, 1, 1, 1, 1 }, true },
            new object[] { new int[] { }, new List<int> { 1 }, false },
            new object[] { new int[] { 1 }, new List<int> { 0 }, false },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };

        private static object[] OverlapsTestCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new List<int> { 0, 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 1, 2, 3 }, true },
            new object[] { new int[] { 1, 2, 3, 4, 5 }, new List<int> { 6, 7, 8, 9, 10 }, false },
            new object[] { new int[] { }, new List<int> { 1 }, false },
            new object[] { new int[] { 1 }, new List<int> { }, false },
            new object[] { new int[] { 1, 2, 3 }, null, false }
        };
    }
}