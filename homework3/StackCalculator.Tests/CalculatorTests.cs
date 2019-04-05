using NUnit.Framework;
using System;

namespace StackCalculator.Tests
{
    [TestFixture(typeof(ListStack))]
    [TestFixture(typeof(ArrayStack))]
    public class CalculatorTests<TStack> where TStack : IStack, new()
    {
        private Calculator testCalculator;

        [SetUp]
        public void Initialize()
        {
            testCalculator = new Calculator(new TStack());
        }

        [Test]
        [TestCase("2 2 +", ExpectedResult = 4)]
        [TestCase("2 10 -", ExpectedResult = -8)]
        [TestCase("3 21 + 10 * 31 11 - 4 * /", ExpectedResult = 3)]
        [TestCase("1234567890 912915757 +", ExpectedResult = 2147483647)]
        [TestCase("2147483647 1 +", ExpectedResult = -2147483648)]
        [TestCase("2 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 *", ExpectedResult = 131072)]
        [TestCase("1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 +" +
                " * * * * * * * * * * 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 -" +
                " * * * * * * * * * * /", ExpectedResult = 1)]
        [TestCase("0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " + - * + - * + - * + - * + - * + - * + - * + - * + -", ExpectedResult = 0)]
        [TestCase("-10 -10 - -20 -20 - -1234567890 -1234567890 - + *", ExpectedResult = 0)]
        [TestCase("2147483647 1 +", ExpectedResult = -2147483648)]
        [TestCase("31415926", ExpectedResult = 31415926)]
        public int ListCalculatorEvaluateTest(string testExpression) => testCalculator.Evaluate(testExpression);

        [Test]
        [TestCase("100 * 100 + 100 - 100 / 100")]
        [TestCase("3.1415 2.7182 +")]
        [TestCase("100 200-")]
        [TestCase("divide five by two PLEASE")]
        [TestCase("5 5 =")]
        [TestCase("1000000000000 2000000000000 *")]
        [TestCase("a b *")]
        [TestCase("")]
        public void IncorrectInputListCalculatorEvaluateTest(string testExpression)
        {
            Assert.Throws<FormatException>(() => testCalculator.Evaluate(testExpression));
        }

        [Test]
        public void DividingByZeroArrayCalculatorEvaluateTest()
        {
            string testExpression = "5 0 /";
            Assert.Throws<DivideByZeroException>(() => testCalculator.Evaluate(testExpression)); ;
        }
    }
}