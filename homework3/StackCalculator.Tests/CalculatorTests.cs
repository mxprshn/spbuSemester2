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
        public void SmokeListEvaluateTest()
        {
            string testExpression = "2 2 +";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void SmokeArrayEvaluateTest()
        {
            string testExpression = "2 2 +";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void NegativeResultListEvaluateTest()
        {
            string testExpression = "2 10 -";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(-8, result);
        }

        [TestMethod()]
        public void NegativeResultArrayEvaluateTest()
        {
            string testExpression = "2 10 -";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(-8, result);
        }

        [TestMethod()]
        public void AllOperationsListEvaluateTest()
        {
            string testExpression = "3 21 + 10 * 31 11 - 4 * /";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void AllOperationsArrayEvaluateTest()
        {
            string testExpression = "3 21 + 10 * 31 11 - 4 * /";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void MaxIntValueResultListEvaluateTest()
        {
            string testExpression = "1234567890 912915757 +";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(2147483647, result);
        }

        [TestMethod()]
        public void MaxIntValueResultArrayEvaluateTest()
        {
            string testExpression = "1234567890 912915757 +";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(2147483647, result);
        }

        [TestMethod()]
        public void IntegerOverflowResultListEvaluateTest()
        {
            string testExpression = "2147483647 1 +";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod()]
        public void IntegerOverflowResultArrayEvaluateTest()
        {
            string testExpression = "2147483647 1 +";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod()]
        public void MultipleOperationsListEvaluateTest()
        {
            string testExpression = "2 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 *";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(131072, result);
        }

        [TestMethod()]
        public void MultipleOperationsArrayEvaluateTest()
        {
            string testExpression = "2 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 *";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(131072, result);
        }

        [TestMethod()]
        public void ALotOfIntermediateCalculationsListEvaluateTest()
        {
            string testExpression = "1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 +" +
                " * * * * * * * * * * 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 -" +
                " * * * * * * * * * * /";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void ALotOfIntermediateCalculationsArrayEvaluateTest()
        {
            string testExpression = "1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 + 1 1 +" +
                " * * * * * * * * * * 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 - 3 1 -" +
                " * * * * * * * * * * /";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void ALotOfZerosListEvaluateTest()
        {
            string testExpression = "0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " + - * + - * + - * + - * + - * + - * + - * + - * + -";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void ALotOfZerosArrayEvaluateTest()
        {
            string testExpression = "0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 * 0 0 + 0 0 - 0 0 *" +
                " + - * + - * + - * + - * + - * + - * + - * + - * + -";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NegativeOperandsListEvaluateTest()
        {
            string testExpression = "-10 -10 - -20 -20 - -1234567890 -1234567890 - + *";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NegativeOperandsArrayEvaluateTest()
        {
            string testExpression = "-10 -10 - -20 -20 - -1234567890 -1234567890 - + *";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NoOperationsListEvaluateTest()
        {
            string testExpression = "31415926";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(31415926, result);
        }

        [TestMethod()]
        public void NoOperationsArrayEvaluateTest()
        {
            string testExpression = "31415926";
            var result = testArrayCalculator.Evaluate(testExpression);
            Assert.AreEqual(31415926, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void InfixNotationListEvaluateTest()
        {
            string testExpression = "100 * 100 + 100 - 100 / 100";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void InfixNotationArrayEvaluateTest()
        {
            string testExpression = "100 * 100 + 100 - 100 / 100";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void FloatNumbersListEvaluateTest()
        {
            string testExpression = "3.1415 2.7182 +";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void FloatNumbersArrayEvaluateTest()
        {
            string testExpression = "3.1415 2.7182 +";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ForgotASpaceListEvaluateTest()
        {
            string testExpression = "100 200-";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ForgotASpaceArrayEvaluateTest()
        {
            string testExpression = "100 200-";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongCharactersListEvaluateTest()
        {
            string testExpression = "divide five by two PLEASE";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongCharactersArrayEvaluateTest()
        {
            string testExpression = "divide five by two PLEASE";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongOperationListEvaluateTest()
        {
            string testExpression = "5 5 =";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void WrongOperationArrayEvaluateTest()
        {
            string testExpression = "5 5 =";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void CalculatingLettersListEvaluateTest()
        {
            string testExpression = "a b *";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void CalculatingLettersArrayEvaluateTest()
        {
            string testExpression = "a b *";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void TooLongNumbersListEvaluateTest()
        {
            string testExpression = "1000000000000 2000000000000 *";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void TooLongNumbersArrayEvaluateTest()
        {
            string testExpression = "1000000000000 2000000000000 *";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void EmptyInputArrayEvaluateTest()
        {
            string testExpression = "";
            _ = testArrayCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void EmptyInputListEvaluateTest()
        {
            string testExpression = "";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividingByZeroListEvaluateTest()
        {
            string testExpression = "5 0 /";
            _ = testListCalculator.Evaluate(testExpression);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividingByZeroArrayEvaluateTest()
        {
            string testExpression = "5 0 /";
            _ = testArrayCalculator.Evaluate(testExpression);
        }
    }
}