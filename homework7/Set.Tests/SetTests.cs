using System;
using GenericSet;
using NUnit.Framework;

namespace Set.Tests
{
    [TestFixture]
    public class SetTests
    {
        public interface IAddTester
        {
            void AddTest();
        }

        public interface IRemoveTester
        {
            void RemoveTest();
        }

        public class AddTester<T> : IAddTester where T : IComparable<T>
        {
            private Set<T> testSet = new Set<T>();
            private T[] valuesToAdd;
            private int expectedAmount;

            public AddTester(T[] valuesToAdd, int expectedAmount)
            {
                this.valuesToAdd = valuesToAdd;
                this.expectedAmount = expectedAmount;
            }

            public void AddTest()
            {
                foreach (var current in valuesToAdd)
                {
                    testSet.Add(current);
                    Assert.IsFalse(testSet.Add(current));
                    Assert.IsTrue(testSet.Contains(current));
                }

                Assert.AreEqual(expectedAmount, testSet.Count);
            }
        }

        [TestCaseSource("AddTestCases")]
        public void RemoveTest(IAddTester tester) => tester.AddTest();

        private static object[] AddTestCases =
        {
            new AddTester<int>(new int[] { 1, 2, 3, 4, 5 }, 5),
            new AddTester<int>(new int[] { 0, 1, -1, 2, -2, 3, -3, -4, 4, 5, -5 }, 11),
            new AddTester<int>(new int[] { 1, 1, 1, 1, 1 }, 1),
            new AddTester<int>(new int[] { 1, 2, 1, 2, 1 }, 2),
            new AddTester<string>(new string[] { "hello", "world", "Hello", "World", "" }, 5),
            new AddTester<string>(new string[] { "January", "February", "March", "February", "January" }, 3)
        };



    }
}
