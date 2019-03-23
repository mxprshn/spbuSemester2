using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void NegativeNumbersCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(- (+ -17 -8) (* -5 -10))");
            Assert.AreEqual(-75, result);
        }

        [TestMethod()]
        public void NegativeNumbersSubtractionCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(- (- -5 -10) (- 0 -5))");
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

        [TestMethod()]
        public void InputWithMoreSpacesCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(  + (  *  10   2)    (       / 60 3 ) )");
            Assert.AreEqual(40, result);
        }

        [TestMethod()]
        public void InputWithLessSpacesCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("(+(*10 2)(/60 3))");
            Assert.AreEqual(40, result);
        }

        [TestMethod()]
        public void JustANumberCalculateTreeTest()
        {
            var result = TreeCalculator.Calculate("100");
            Assert.AreEqual(100, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongBracketsCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("(+ ((* 2 5) 7))");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void EmptyInputCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongOperationCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("(+ (# 10 (| 20 7)) (@ 60 2))");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void NoOperationsCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("((10(20 7))(60 2))");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void FloatOperandsCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("(- (+ 17.2 3.1415) (* 2.718 8.0))");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void CompletelyWrongInputCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("I'm strange and want to calculate this string.");
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void MissedOperandCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("(+ (* 2) (- 6 3))");
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividingByZeroCalculateTreeTest()
        {
            _ = TreeCalculator.Calculate("(+ (/ 2 0) (- 6 3))");
        }
    }
}