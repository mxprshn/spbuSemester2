using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class ExpressionTests
    {
        private Expression testExpression;

        [SetUp]
        public void SetUp()
        {
            testExpression = new Expression();
        }

        [TestCase("B", ExpectedResult = "(")]
        [TestCase("BB", ExpectedResult = "((")]
        [TestCase("BBB", ExpectedResult = "(((")]
        [TestCase("BBB10BBBB", ExpectedResult = "(((10)))")]
        [TestCase("B1B", ExpectedResult = "(1)")]
        [TestCase("B1BB", ExpectedResult = "(1)")]
        [TestCase("B+B", ExpectedResult = "((")]
        [TestCase("B,B", ExpectedResult = "((")]
        [TestCase("B100B", ExpectedResult = "(100)")]
        [TestCase("B1+1B", ExpectedResult = "(1+1)")]
        [TestCase("B1,5B", ExpectedResult = "(1,5)")]
        [TestCase("B1,5,B", ExpectedResult = "(1,5)")]
        [TestCase("BB1+5*6B+7B", ExpectedResult = "((1+5*6)+7)")]
        [TestCase("B11,56/3B+B3-7,B-B44+B5*3,1415BB", ExpectedResult = "(11,56/3)+(3-7,44+(5*3,1415))")]
        [TestCase("+8-7", ExpectedResult = "8-7")]
        [TestCase("********3", ExpectedResult = "3")]
        public string AddTest(string commands)
        {
            foreach (var current in commands)
            {
                if (current == 'B')
                {
                    testExpression.AddBracket();
                }
                else if (current == ',')
                {
                    testExpression.AddComma();
                }
                else if (char.IsDigit(current))
                {
                    testExpression.AddDigit(current);
                }
                else
                {
                    testExpression.AddOperation(current);
                }
            }

            return testExpression.ToString();
        }
    }
}
