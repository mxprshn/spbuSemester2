using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    class InfixCalculatorTests
    {
        private const double Epsilon = 0.00000001;

        private bool CompareDoubles(double first, double second) => Math.Abs(first - second) < Epsilon;

        [TestCase("0,00009+3", 3.00009)]
        [TestCase("0,4000000+0,6000000000000", 1)]
        [TestCase("0,00009-3", -2.99991)]
        [TestCase("0,00009×3", 0.00027)]
        [TestCase("0,0000000015×1000000000", 1.5)]
        [TestCase("10242048×-100000000000", -1024204800000000000)]
        [TestCase("0,00000002×0,00000001", 0.00000000000002)]
        [TestCase("0,00009÷3", 0.00003)]
        [TestCase("0,0000002048÷-0,0000000001", -2048)]
        [TestCase("0,00009%100000", 0.09)]
        [TestCase("-20%300", -60)]
        [TestCase("0,9%2000%0,01", 0.0018)]
        [TestCase("0,0 + 0-0 ×0,0  %0", 0)]
        [TestCase("3,1415926--10,8", 13.9415926)]
        [TestCase("1+2 + 3  + 4     +5", 15)]        
        [TestCase("((3+1) - (2×2))", 0)]
        [TestCase("(-100+((2×((1+1)-1))÷2))", -99)]        
        [TestCase("2077", 2077)]
        [TestCase("(((((3))))+7)", 10)]
        [TestCase("0-(-1-2-3-4-5-6)", 21)]        
        [TestCase("(10-8)×(-10+12) × (-6÷-3)× 2", 16)]
        [TestCase("(((((((2×2)×2)×2)×2)×2)×2)×2)×2", 512)]
        [TestCase("2+2×2", 6)]
        [TestCase("-1024+00000,1", -1023.9)]
        public void CalculateTest(string expression, double expectedResult)
        {
            var result = InfixCalculator.Calculate(expression);
            Assert.IsTrue(CompareDoubles(result, expectedResult));
        }

        [TestCase("")]
        [TestCase("0,00,2+10")]
        [TestCase("((1+15))-9)")]
        [TestCase("2077++2048")]
        [TestCase("helloworld")]
        [TestCase("-3,12×0.121212")]
        [TestCase("1 2 3 4 5 + - +")]
        [TestCase("+")]
        [TestCase("1-2+3&4#5")]
        [TestCase("(1+2×(22-6")]
        [TestCase("(((((0")]
        [TestCase("0---15")]
        public void IncorrectInputCalculateTest(string expression)
        {
            Assert.Throws<FormatException>(() => InfixCalculator.Calculate(expression));
        }

        public void DividingByZeroCalculateTest()
        {
            Assert.Throws<DivideByZeroException>(() => InfixCalculator.Calculate("4096÷(555-555)"));
        }
    }
}