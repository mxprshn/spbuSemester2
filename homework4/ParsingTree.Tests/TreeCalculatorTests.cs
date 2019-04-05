using NUnit.Framework;
using System;

namespace ParsingTree.Tests
{
    [TestFixture]
    public class TreeCalculatorTests
    {
        [Test]
        [TestCase("(+ 2 2)", ExpectedResult = 4)]
        [TestCase("(* 2 2)", ExpectedResult = 4)]
        [TestCase("(- 2 2)", ExpectedResult = 0)]
        [TestCase("(/ 2 2)", ExpectedResult = 1)]
        [TestCase("(* (+ 5 10) 2)", ExpectedResult = 30)]
        [TestCase("(+ (+ 1 1) (* 2 2))", ExpectedResult = 6)]
        [TestCase("(+ (+ 0 0) (* 1 0))", ExpectedResult = 0)]
        [TestCase("(- (+ -17 -8) (* -5 -10))", ExpectedResult = -75)]
        [TestCase("(- (- -5 -10) (- 0 -5))", ExpectedResult = 0)]
        [TestCase("(+ (* 10 (- 20 7)) (/ 60 2))", ExpectedResult = 160)]
        [TestCase("(- (* 10000 31415) (/ 65536 2048))", ExpectedResult = 314149968)]
        [TestCase("(+ (+ (+ (+ (+ (+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1)))" +
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
                "(+ (+ (+ 1 1) (+ 1 1)) (+ (+ 1 1) (+ 1 1))))))))", ExpectedResult = 256)]
        [TestCase("(* (* (* (* (* (* (* (* (* (* (* (* (* (* (* 2" +
                " 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2) 2)", ExpectedResult = 65536)]
        [TestCase("(* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 " +
                "(* 2 (* 2 (* 2 (* 2 (* 2 (* 2 (* 2 2)))))))))))))))", ExpectedResult = 65536)]
        [TestCase("(  + (  *  10   2)    (       / 60 3 ) )", ExpectedResult = 40)]
        [TestCase("(+(*10 2)(/60 3))", ExpectedResult = 40)]
        [TestCase("100", ExpectedResult = 100)]
        public int CalculateTreeTest(string testTree) => TreeCalculator.Calculate(testTree);

        [Test]
        [TestCase("(+ ((* 2 5) 7))")]
        [TestCase("")]
        [TestCase("(+ (# 10 (| 20 7)) (@ 60 2))")]
        [TestCase("((10(20 7))(60 2))")]
        [TestCase("(- (+ 17.2 3.1415) (* 2.718 8.0))")]
        [TestCase("I'm strange and want to calculate this string.")]
        [TestCase("(+ (* 2) (- 6 3))")]
        public void IncorrectInputCalculateTreeTest(string testString)
        {
            Assert.Throws<FormatException>(() => TreeCalculator.Calculate(testString));
        }

        [Test]
        public void DividingByZeroCalculateTreeTest()
        {
            Assert.Throws<DivideByZeroException>(() => TreeCalculator.Calculate("(+ (/ 2 0) (- 6 3))"));
        }
    }
}