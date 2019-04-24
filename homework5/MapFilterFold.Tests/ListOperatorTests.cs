using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace MapFilterFold.Tests
{
    [TestFixture()]
    public class ListOperatorTests
    {
        [TestCaseSource("MapTestSource")]
        public void MapTest(List<int> testList, Func<int, int> testModifier, List<int> expectedResult)
        {
            var result = ListOperator.Map(testList, testModifier);
            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [TestCaseSource("FilterTestSource")]
        public void FilterTest(List<int> testList, Predicate<int> testFilter, List<int> expectedResult)
        {
            var result = ListOperator.Filter(testList, testFilter);
            Assert.IsTrue(expectedResult.SequenceEqual(result));
        }

        [TestCaseSource("FoldTestSource")]
        public void FoldTest(List<int> testList, int testAccumulated, Func<int, int, int> testAccumulator, int expectedAccumulated)
        {
            var result = ListOperator.Fold(testList, testAccumulated, testAccumulator);
            Assert.AreEqual(expectedAccumulated, result);
        }

        private static object[] MapTestSource =
        {
            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new Func<int, int>(element => 5 * element),
                new List<int> { 5, 10, 15, 20, 25 },
            },

            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new Func<int, int>(element => element),
                new List<int> { 1, 2, 3, 4, 5 },
            },

            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new Func<int, int>(element => -2048),
                new List<int> { -2048, -2048, -2048, -2048, -2048 },
            },

            new object[]
            {
                new List<int> { 2077 },
                new Func<int, int>(element => element - 2000),
                new List<int> { 77 },
            },

            new object[]
            {
                new List<int> {},
                new Func<int, int>(element => element / 0),
                new List<int> {},
            }
        };

        private static object[] FilterTestSource =
        {
            new object[]
            {
                new List<int> { 1, 0, 3, 0, 5 },
                new Predicate<int>(element => element != 0),
                new List<int> { 1, 3, 5 },
            },

            new object[]
            {
                new List<int> { 100, 10000, 10, 1, 1 },
                new Predicate<int>(element => element % 10 != 0),
                new List<int> { 1, 1 },
            },

            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new Predicate<int>(element => element > 0),
                new List<int> { 1, 2, 3, 4, 5 },
            },

            new object[]
            {
                new List<int> {},
                new Predicate<int>(element => element % 0 == 0),
                new List<int> {},
            },

            new object[]
            {
                new List<int> { 2077 },
                new Predicate<int>(element => element != 2077),
                new List<int> {},
            },
        };

        private static object[] FoldTestSource =
        {
            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                0,
                new Func<int, int, int>((accumulated, current) => accumulated + current),
                15,
            },

            new object[]
            {
                new List<int> {},
                2077,
                new Func<int, int, int>((accumulated, current) => accumulated + current),
                2077,
            },

            new object[]
            {
                new List<int> { 2, 2, 2, 2, 2, 2, 2 },
                2,
                new Func<int, int, int>((accumulated, current) => accumulated * current),
                256,
            },

            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                2077,
                new Func<int, int, int>((accumulated, current) => 1024),
                1024,
            },

            new object[]
            {
                new List<int> { 1, 2, 3, 4, 5 },
                0,
                new Func<int, int, int>((accumulated, current) => accumulated),
                0,
            },
        };
    }
}
