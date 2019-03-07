using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void NegativeResultListEvaluateTest()
        {
            string testExpression = "2 10 -";
            var result = testListCalculator.Evaluate(testExpression);
            Assert.AreEqual(-8, result);
        }
    }
}