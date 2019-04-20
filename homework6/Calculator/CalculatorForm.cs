using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private ExpressionBuilder currentExpression = new ExpressionBuilder();

        private void GetResult()
        {
            try
            {
                if (currentExpression.Complete())
                {
                    var result = InfixCalculator.Calculate(currentExpression.Expression);
                    var evaluatedExpression = currentExpression.Expression;
                    currentExpression.Clear();
                    currentExpression.ResetCurrentNumber(result);
                    expressionTextBox.Text = evaluatedExpression;
                }
            }

            catch (DivideByZeroException)
            {
                currentExpression.Clear();
                currentNumberTextBox.Text = "ой";
            }
        }

        public CalculatorForm()
        {
            InitializeComponent();
            currentNumberTextBox.DataBindings.Add("Text", currentExpression, "CurrentNumber");
            expressionTextBox.DataBindings.Add("Text", currentExpression, "Expression");
        }        

        private void CommaButtonClick(object sender, EventArgs e) => currentExpression.AddComma();
        private void BracketButtonClick(object sender, EventArgs e) => currentExpression.AddBracket();

        private void ResultButtonClick(object sender, EventArgs e) => GetResult();

        private void ZeroButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('0');
        private void OneButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('1');
        private void TwoButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('2');
        private void ThreeButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('3');
        private void FourButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('4');
        private void FiveButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('5');
        private void SixButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('6');
        private void SevenButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('7');
        private void EightButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('8');
        private void NineButtonClick(object sender, EventArgs e) => currentExpression.AddDigit('9');

        private void ClearButtonClick(object sender, EventArgs e) => currentExpression.Clear();


        private void DivisionButtonClick(object sender, EventArgs e) => currentExpression.AddOperation('÷');
        private void CrossButtonClick(object sender, EventArgs e) => currentExpression.AddOperation('×');
        private void PercentButtonClick(object sender, EventArgs e) => currentExpression.AddOperation('%');
        private void MinusButtonClick(object sender, EventArgs e) => currentExpression.AddOperation('-');
        private void PlusButtonClick(object sender, EventArgs e) => currentExpression.AddOperation('+');

        private void BackspaceButtonClick(object sender, EventArgs e) => currentExpression.DeleteLast();

        private void CalculatorFormKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                currentExpression.AddDigit(e.KeyChar);
            }
            else if (e.KeyChar == '+')
            {
                currentExpression.AddOperation('+');
            }
            else if (e.KeyChar == '-')
            {
                currentExpression.AddOperation('-');
            }
            else if (e.KeyChar == '*')
            {
                currentExpression.AddOperation('×');
            }
            else if (e.KeyChar == '/')
            {
                currentExpression.AddOperation('÷');
            }
            else if (e.KeyChar == '%')
            {
                currentExpression.AddOperation('%');
            }
            else if (e.KeyChar == ',')
            {
                currentExpression.AddComma();
            }
            else if (e.KeyChar == '(' || e.KeyChar == ')')
            {
                currentExpression.AddBracket();
            }
            else if (e.KeyChar == '=')
            {
                GetResult();
            }
        }
    }
}
