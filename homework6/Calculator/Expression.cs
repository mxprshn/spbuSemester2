using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Expression
    {
        private string textExpression = "";

        public string LastNumber { get; private set; } = "";
        private char lastSymbol = ' ';

        private bool wasComma = false;

        private char[] operations = new char[] { '*', '/', '+', '-', '%' };
        private Stack<char> bracketStack = new Stack<char>();

        public override string ToString() => textExpression;

        private bool IsOperation(char symbol) => operations.Contains(symbol);

        public void CloseBrackets()
        {
            if (char.IsDigit(lastSymbol))
            {
                textExpression += new string(')', bracketStack.Count);
            }
        }

        public void AddBracket()
        {
            if ((char.IsDigit(lastSymbol) || lastSymbol == ')') && bracketStack.Count != 0)
            {
                textExpression += ')';
                lastSymbol = ')';
                bracketStack.Pop();
                wasComma = false;
                LastNumber = "";
            }
            else if (lastSymbol == ' ' || lastSymbol == '(' || IsOperation(lastSymbol))
            {
                textExpression += '(';
                lastSymbol = '(';
                bracketStack.Push('(');
            }
        }

        public void AddDigit(char digit)
        {
            if (!char.IsDigit(digit))
            {
                throw new ArgumentException();
            }

            if (lastSymbol != ')' && (LastNumber.Length == 0 || LastNumber[0] != '0' || wasComma))
            {
                textExpression += digit;
                lastSymbol = digit;
                LastNumber += digit;
            }
        }

        public void AddComma()
        {
            if (!wasComma && char.IsDigit(lastSymbol))
            {
                textExpression += ',';
                wasComma = true;
                LastNumber += ',';
                lastSymbol = ',';
            }
        }

        public void AddOperation(char operation)
        {
            if (!IsOperation(operation))
            {
                throw new ArgumentException();
            }

            if (lastSymbol == ')' || char.IsDigit(lastSymbol))
            {
                textExpression += operation;
                wasComma = false;
                lastSymbol = operation;
                LastNumber = "";
            }
            else if (operation == '-' && lastSymbol != '-' && LastNumber.Length == 0)
            {
                textExpression += operation;
                lastSymbol = operation;
            }
        }

        public void Clear()
        {
            textExpression = "";
            LastNumber = "";
            lastSymbol = ' ';
            bracketStack.Clear();
            wasComma = false;
        }

        public void ClearLast()
        {
            if (LastNumber.Length != 0)
            {
                if (LastNumber[LastNumber.Length - 1] == ',')
                {
                    wasComma = false;
                }

                textExpression = textExpression.Remove(textExpression.Length - 1);
                LastNumber = LastNumber.Remove(LastNumber.Length - 1);

                if (textExpression.Length != 0)
                {
                    lastSymbol = textExpression[textExpression.Length - 1];
                }
                else
                {
                    lastSymbol = ' ';
                }
            }
        }
    }
}
