using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingTree.Tests
{
    [TestClass()]
    public class TreeCalculatorTests
    {
        [TestMethod()]
        public void CalculateTreeTest()
        {
            Assert.AreEqual(4, TreeCalculator.CalculateTree("..\\..\\Input.txt"));
        }
    }
}