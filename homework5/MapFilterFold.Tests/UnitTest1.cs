using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MapFilterFold.Tests
{
    [TestFixture()]
    public class ListModifierTests
    {
        [Test]
        public void MapTest(int[] testList)
        {
            var result = ListModifier.Map(new List<int> { 5, 5, 10 }, i => i * 5);
            foreach (var i int )
        }
    }
}
