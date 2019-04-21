using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class ExpressionBuilderTests
    {
        private ExpressionBuilder testExpressionBuilder;

        [SetUp]
        public void SetUp() => testExpressionBuilder = new ExpressionBuilder();

        private void ParseCommands(string commands)
        {
            foreach (var current in commands)
            {
                if (current == 'B')
                {
                    testExpressionBuilder.AddBracket();
                }
                else if (current == ',')
                {
                    testExpressionBuilder.AddComma();
                }
                else if (char.IsDigit(current))
                {
                    testExpressionBuilder.AddDigit(current);
                }
                else
                {
                    testExpressionBuilder.AddOperation(current);
                }
            }
        }

        [TestCase("B", "(", "")]
        [TestCase("BBB", "(((", "")]
        [TestCase("BBB10BBBBB", "(((10)))", "")]
        [TestCase("B+B", "((", "")]
        [TestCase("B,B", "(0,0)", "")]
        [TestCase("BB+", "((", "")]
        [TestCase("BB,", "((", "0,")]
        [TestCase("BB-", "((", "-")]
        [TestCase(",BB", "(0,0)", "")]
        [TestCase("+BB", "((", "")]
        [TestCase("-BB", "((", "-")]
        [TestCase("B-B1024BBB", "((-1024))", "")]
        [TestCase("B-B1024", "((", "-1024")]
        [TestCase("B2048BB1024", "(2048)", "")]
        [TestCase("B-B1024", "((", "-1024")]
        [TestCase("B-8+BB16--2B%4×B128-256BBBBBB", "(-8+((16--2)%4×(128-256)))", "")]
        [TestCase("2048", "", "2048")]
        [TestCase("00000", "", "0")]
        [TestCase(",,,,,", "", "0,")]
        [TestCase("2048,+", "2048,0+", "")]
        [TestCase("0+31415926", "0+", "31415926")]
        [TestCase("0-31415926", "0-", "31415926")]
        [TestCase("0×31415926", "0×", "31415926")]
        [TestCase("0÷31415926", "0÷", "31415926")]
        [TestCase("0%31415926", "0%", "31415926")]
        [TestCase("+", "", "")]
        [TestCase("+++%%%---×××÷÷÷", "", "-")]
        [TestCase(",--,", "0,0-", "-0,")]
        [TestCase("-----", "", "-")]
        [TestCase("+++10++20+++30++++40", "10+20+30+", "40")]
        public void AddTest(string commands, string expectedExpresssion, string expectedCurrentNumber)
        {
            ParseCommands(commands);
            Assert.AreEqual(expectedExpresssion, testExpressionBuilder.Expression);
            Assert.AreEqual(expectedCurrentNumber, testExpressionBuilder.CurrentNumber);
        }

        [TestCase("1024", ExpectedResult = "1024")]
        [TestCase("BB2048-128,", ExpectedResult = "((2048-128,0))")]
        [TestCase(",", ExpectedResult = "0,0")]
        [TestCase("B-8+BB16--2B%4×B128-256", ExpectedResult = "(-8+((16--2)%4×(128-256)))")]
        [TestCase("B-8+BB16--2B%4×B128-256BBBBBB", ExpectedResult = "(-8+((16--2)%4×(128-256)))")]
        public string SuccessfulCompleteTest(string commands)
        {
            ParseCommands(commands);
            var result = testExpressionBuilder.Complete();
            Assert.AreEqual("", testExpressionBuilder.CurrentNumber);
            Assert.IsTrue(result);
            return testExpressionBuilder.Expression;
        }

        [TestCase("")]
        [TestCase("1024+")]
        [TestCase("BBBBB")]
        [TestCase("1024%-")]
        [TestCase("-")]
        [TestCase("B1024+B2048--")]
        public void FailedCompleteTest(string commands)
        {
            ParseCommands(commands);
            var beforeComplete = testExpressionBuilder.Expression;
            var result = testExpressionBuilder.Complete();
            Assert.AreEqual(beforeComplete, testExpressionBuilder.Expression);
            Assert.IsFalse(result);
        }

        [TestCase("-2048", ExpectedResult = "-")]
        [TestCase("-2048--", ExpectedResult = "")]
        [TestCase("-2048%128", ExpectedResult = "")]
        [TestCase("-8", ExpectedResult = "")]
        [TestCase(",", ExpectedResult = "")]
        [TestCase("31415926", ExpectedResult = "3141")]
        [TestCase("", ExpectedResult = "")]
        public string DeleteLastTest(string commands)
        {
            ParseCommands(commands);
            var beforeDelete = testExpressionBuilder.Expression;

            for (var i = 0; i < 4; ++i)
            {
                testExpressionBuilder.DeleteLast();
            }

            Assert.AreEqual(beforeDelete, testExpressionBuilder.Expression);
            return testExpressionBuilder.CurrentNumber;
        }

        [TestCase("")]
        [TestCase("-0,1024")]
        [TestCase("B-8+BB16--2B%4×B128-256")]
        public void ClearTest(string commands)
        {
            ParseCommands(commands);
            testExpressionBuilder.Clear();
            Assert.AreEqual("", testExpressionBuilder.CurrentNumber);
            Assert.AreEqual("", testExpressionBuilder.Expression);
        }

        [TestCase("-0,2048", 1024, ExpectedResult = "1024")]
        [TestCase("", 1024, ExpectedResult = "1024")]
        [TestCase("", -1024.128, ExpectedResult = "-1024,128")]
        [TestCase("", 0.0, ExpectedResult = "0")]
        [TestCase("", -0.1234567891011, ExpectedResult = "-0,1234567891")]
        [TestCase("", -1.052033E+003, ExpectedResult = "-1052,033")]
        public string ResetCurrentNumberTest(string commands, double value)
        {
            ParseCommands(commands);
            testExpressionBuilder.ResetCurrentNumber(value);
            return testExpressionBuilder.CurrentNumber;
        }

        [Test]
        public void InvalidOperationAddTest()
        {
            Assert.Throws<ArgumentException>(() => testExpressionBuilder.AddOperation('&'));
        }

        [Test]
        public void NotDigitAddTest()
        {
            Assert.Throws<ArgumentException>(() => testExpressionBuilder.AddDigit('+'));
        }
    }
}