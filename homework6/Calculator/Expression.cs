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
        private char lastSymbol = ' ';
        private bool wasComma = false;
        private char[] operations = new char[] { '*', '/', '+', '-' };
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

            if (lastSymbol != ')')
            {
                textExpression += digit;
                lastSymbol = digit;
            }
        }

        public void AddComma()
        {
            if (!wasComma && char.IsDigit(lastSymbol))
            {
                textExpression += ',';
                wasComma = true;
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
            }
        }

        public void Clear()
        {
            textExpression = "";
            lastSymbol = ' ';
            bracketStack.Clear();
            wasComma = false;
        }
    }
}
