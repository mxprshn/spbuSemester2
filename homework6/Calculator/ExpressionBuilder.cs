using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ExpressionBuilder
    {
        private string textExpression = "";

        // public List<string> Tokens { get; } = new List<string>();

        public string CurrentNumber { get; private set; } = "";
        private char LastSymbol => textExpression.Length == 0 ? ' ' : textExpression[textExpression.Length - 1];
        private bool WasComma => CurrentNumber.Contains(',');
        private bool HasNumberDigits => CurrentNumber.Length != 0 && CurrentNumber != "-";

        private static readonly char[] operations = new char[] { '*', '/', '+', '-', '%' };
        private Stack<char> bracketStack = new Stack<char>();

        public override string ToString() => textExpression;

        private bool IsOperation(char symbol) => operations.Contains(symbol);

        private void AddLastNumber()
        {
            textExpression += CurrentNumber;
            CurrentNumber = "";
        }

        public void CloseBrackets()
        {
            AddLastNumber();
            if (char.IsDigit(LastSymbol))
            {
                textExpression += new string(')', bracketStack.Count);
            }
        }

        public void AddBracket()
        {
            if ((HasNumberDigits || LastSymbol == ')') && bracketStack.Count != 0)
            {
                //textExpression += ')';
                //bracketStack.Pop();
                //wasComma = false;
                //LastNumber = "";

                AddLastNumber();
                textExpression += ')';
                bracketStack.Pop();
            }
            else if (LastSymbol == ' ' || LastSymbol == '(' || IsOperation(LastSymbol))
            {
                textExpression += '(';
                bracketStack.Push('(');
            }
        }

        public void AddDigit(char digit)
        {
            if (!char.IsDigit(digit))
            {
                throw new ArgumentException();
            }

            if (LastSymbol != ')' && CurrentNumber != "0" && CurrentNumber != "-0")
            {
                //textExpression += digit;
                CurrentNumber += digit;
            }
        }

        public void AddComma()
        {
            if (!WasComma && HasNumberDigits)
            {
                //textExpression += ',';
                //WasComma = true;
                CurrentNumber += ',';
            }
        }

        public void AddOperation(char operation)
        {
            if (!IsOperation(operation))
            {
                throw new ArgumentException();
            }

            if (LastSymbol == ')' || HasNumberDigits)
            {
                AddLastNumber();
                //tokens.Add(operation.ToString());
                textExpression += operation;
                //WasComma = false;
                //LastNumber = "";
            }
            else if (operation == '-' && LastSymbol != '-' && CurrentNumber.Length == 0)
            {
                //textExpression += operation;
                //tokens.Add(operation.ToString());
                CurrentNumber += operation;
            }
        }

        public void Clear()
        {
            textExpression = "";
            //tokens.Clear();
            CurrentNumber = "";
            bracketStack.Clear();
            //WasComma = false;
        }

        public void ClearLast()
        {
            if (CurrentNumber.Length != 0)
            {
                //if (LastNumber[LastNumber.Length - 1] == ',')
                //{
                //    WasComma = false;
                //}

                //textExpression = textExpression.Remove(textExpression.Length - 1);
                CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
            }
        }
    }
}
