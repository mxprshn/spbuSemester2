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
        private Expression currentExpression = new Expression();


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('0');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void CommaButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddComma();
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void BracketButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddBracket();
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {

        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('1');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('2');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('3');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('7');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            currentExpression.Clear();
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void SlashButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddOperation('/');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void AsteriskButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddOperation('*');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            currentExpression.ClearLast();
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('8');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('9');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddOperation('%');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('4');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('5');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddDigit('6');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddOperation('-');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            currentExpression.AddOperation('+');
            this.expressionTextBox.Text = currentExpression.ToString();
            this.currentNumberTextBox.Text = currentExpression.LastNumber;
        }
    }
}
