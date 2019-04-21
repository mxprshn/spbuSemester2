using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class InfixCalculatorTests
    {
        private const double Epsilon = 1E-10;

        private bool CompareDoubles(double first, double second) => Math.Abs(first - second) < Epsilon;

        [TestCase("0,00009+0,00009", 0.00018)]
        public void CalculateTest(string expression, double expectedResult)
        {
            var result = InfixCalculator.Calculate(expression);
            Assert.IsTrue(CompareDoubles(result, expectedResult));
        }
    }
}
