using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsingTree;
using System;

namespace ParsingTree.Tests
{
    [TestClass()]
    public class TreeCalculatorTests
    {
        [TestMethod()]
        public void SmokeAdditionCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+ 2 2)");
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void SmokeMultiplicationCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(* 2 2)");
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void SmokeSubtractionCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(- 2 2)");
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void SmokeDivisionCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(/ 2 2)");
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void OneSubtreeCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(* (+ 5 10) 2)");
            Assert.AreEqual(30, result);
        }

        [TestMethod()]
        public void TwoSubtreesCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+ (+ 1 1) (* 2 2))");
            Assert.AreEqual(6, result);
        }

        [TestMethod()]
        public void SomeZerosCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+ (+ 0 0) (* 1 0))");
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void AllOperationsCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+ (* 10 (- 20 7)) (/ 60 2))");
            Assert.AreEqual(160, result);
        }

        [TestMethod()]
        public void LongerNumbersCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(- (* 10000 31415) (/ 65536 2048))");
            Assert.AreEqual(314149968, result);
        }

        [TestMethod()]
        public void HighTreeCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+ (+ (+ (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))) (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))))) (+ (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))) (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))))) (+ (+ (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))) (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))))) (+ (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))) (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))) (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))))))");
            Assert.AreEqual(256, result);
        }

        [TestMethod()]
        public void HighLeftTreeCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(* (* (* (* (* (* (* (* (* (* (* (* (* (* (* 2" +
                " 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2)");
            Assert.AreEqual(65536, result);
        }

        [TestMethod()]
        public void HighRightTreeCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 " +
                "(* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 2)))))))))))))))");
            Assert.AreEqual(65536, result);
        }
    }
}