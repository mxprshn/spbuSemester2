using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackCalculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private Calculator testListCalculator;
        private Calculator testArrayCalculator;

        [TestInitialize()]
        public void Initialize()
        {
            testListCalculator = new Calculator(new ListStack());
            testArrayCalculator = new Calculator(new ArrayStack());
        }

        [TestMethod()]
        [DataRow("2 2 +", 4)]
        [DataRow("2 10 -", -8)]
        [DataRow("3 21 + 10 * 31 11 - 4 * /", 3)]
        [DataRow("1234567890 912915757 +", 2147483647)]
        [DataRow("2147483647 1 +", -2147483648)]
        [DataRow("2 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 *", 131072)]
        [DataRow("1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 +" +
                " * * * * * * * * * * 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 -" +
                " * * * * * * * * * * /", 1)]
        [DataRow("0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " + - * + - * + - * + - * + - * + - * + - * + - * + -", 0)]
        [DataRow("-10 -10 - -20 -20 - -1234567890 -1234567890 - + *", 0)]
        [DataRow("2147483647 1 +", -2147483648)]
        [DataRow("31415926", 31415926)]
        public void ListCalculatorEvaluateTest(string testExpression, int expectedResult)
        {
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        [DataRow("2 2 +", 4)]
        [DataRow("2 10 -", -8)]
        [DataRow("3 21 + 10 * 31 11 - 4 * /", 3)]
        [DataRow("1234567890 912915757 +", 2147483647)]
        [DataRow("2147483647 1 +", -2147483648)]
        [DataRow("2 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 *", 131072)]
        [DataRow("1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 +" +
        " * * * * * * * * * * 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 -" +
        " * * * * * * * * * * /", 1)]
        [DataRow("0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
        " 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
        " + - * + - * + - * + - * + - * + - * + - * + - * + -", 0)]
        [DataRow("-10 -10 - -20 -20 - -1234567890 -1234567890 - + *", 0)]
        [DataRow("2147483647 1 +", -2147483648)]
        [DataRow("31415926", 31415926)]
        public void ArrayCalculatorEvaluateTest(string testExpression, int expectedResult)
        {
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        [DataRow("100 * 100 + 100 - 100 / 100")]
        [DataRow("3.1415 2.7182 +")]
        [DataRow("100 200-")]
        [DataRow("divide five by two PLEASE")]
        [DataRow("5 5 =")]
        [DataRow("1000000000000 2000000000000 *")]
        [DataRow("a b *")]
        [DataRow("")]
        public void IncorrectInputListCalculatorEvaluateTest(string testExpression)
        {
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        [DataRow("100 * 100 + 100 - 100 / 100")]
        [DataRow("3.1415 2.7182 +")]
        [DataRow("100 200-")]
        [DataRow("divide five by two PLEASE")]
        [DataRow("5 5 =")]
        [DataRow("1000000000000 2000000000000 *")]
        [DataRow("a b *")]
        [DataRow("")]
        public void IncorrectInputArrayCalculatorEvaluateTest(string testExpression)
        {
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividingByZeroListCalculatorEvaluateTest()
        {
            string testExpression = "5 0 /";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividingByZeroArrayCalculatorEvaluateTest()
        {
            string testExpression = "5 0 /";
            _ = testArrayCalculator.Evaluate(testExpression);
        }
    }
}