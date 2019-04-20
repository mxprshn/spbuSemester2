using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator
{
    /// <summary>
    /// Class building a correct infix notation expression from tokens.
    /// </summary>
    public class ExpressionBuilder : INotifyPropertyChanged
    {
        /// <summary>
        /// Event of changing the Expression or CurrentNumber properties.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string expression = "";
        private string currentNumber = "";
        private static readonly char[] operations = new char[] { '×', '÷', '+', '-', '%' };

        /// <summary>
        /// Expression built at the moment.
        /// </summary>
        public string Expression
        {
            get => expression;

            private set
            {
                expression = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Buffer for a number which can be added to the expression.
        /// </summary>
        public string CurrentNumber
        {
            get => currentNumber;

            private set
            {
                currentNumber = value;
                NotifyPropertyChanged();
            }
        }

        private char LastSymbol => expression.Length == 0 ? ' ' : expression[expression.Length - 1];
        private bool WasComma => CurrentNumber.Contains(',');
        private bool HasNumberDigits => CurrentNumber.Length != 0 && CurrentNumber != "-";

        private Stack<char> bracketStack = new Stack<char>();

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsOperation(char symbol) => operations.Contains(symbol);

        private void AddCurrentNumber()
        {
            Expression += CurrentNumber;
            CurrentNumber = "";
        }

        /// <summary>
        /// Resets the CurrentNumber property to a specific double value.
        /// </summary>
        /// <param name="newValue">New value of CurrentNumber.</param>
        public void ResetCurrentNumber(double newValue)
        {
            CurrentNumber = newValue.ToString();
        }

        /// <summary>
        /// Makes the built expression finally correct, if CurrentNumber value allows it.
        /// </summary>
        /// <returns>True if the expression was completed, False otherwise.</returns>
        public bool Complete()
        {
            if (!HasNumberDigits)
            {
                return false;
            }

            AddCurrentNumber();

            if (char.IsDigit(LastSymbol))
            {
                Expression += new string(')', bracketStack.Count);
            }

            return true;
        }

        /// <summary>
        /// Adds an opening or closing bracket to the Expression if possible.
        /// </summary>
        public void AddBracket()
        {
            if ((HasNumberDigits || LastSymbol == ')') && bracketStack.Count != 0)
            {
                AddCurrentNumber();
                Expression += ')';
                bracketStack.Pop();
            }
            else if (LastSymbol == ' ' || LastSymbol == '(' || IsOperation(LastSymbol))
            {
                Expression += '(';
                bracketStack.Push('(');
            }
        }

        /// <summary>
        /// Adds a new decimal digit to the CurrentNumber if possible.
        /// </summary>
        /// <param name="digit">New digit to add.</param>
        /// <exception cref="ArgumentException">Thrown in the case of non-digit argument value.</exception>
        public void AddDigit(char digit)
        {
            if (!char.IsDigit(digit))
            {
                throw new ArgumentException();
            }

            if (LastSymbol != ')' && CurrentNumber != "0" && CurrentNumber != "-0")
            {
                CurrentNumber += digit;
            }
        }

        /// <summary>
        /// Adds a comma to the CurrentNumber if possible or zero and comma if the CurrentNumber has no digits..
        /// </summary>
        public void AddComma()
        {
            if (!WasComma && HasNumberDigits)
            {
                CurrentNumber += ',';
            }

            if (!HasNumberDigits)
            {
                CurrentNumber += "0,";
            }
        }

        /// <summary>
        /// Adds a new operation symbol to the Expression or minus sign to the CurrentNumber if possible.
        /// </summary>
        /// <param name="operation">New operation or minus sign to add.</param>
        /// <exception cref="ArgumentException">Thrown in case of invalid operation symbol in argument.</exception>
        public void AddOperation(char operation)
        {
            if (!IsOperation(operation))
            {
                throw new ArgumentException();
            }

            if (LastSymbol == ')' || HasNumberDigits)
            {
                AddCurrentNumber();
                Expression += operation;
            }
            else if (operation == '-' && CurrentNumber.Length == 0)
            {
                CurrentNumber += operation;
            }
        }
        
        /// <summary>
        /// Clears the CurrentNumber and the Expression.
        /// </summary>
        public void Clear()
        {
            Expression = "";
            CurrentNumber = "";
            bracketStack.Clear();
        }

        /// <summary>
        /// Deletes the last token from the CurrentNumber.
        /// </summary>
        public void DeleteLast()
        {
            if (CurrentNumber.Length != 0)
            {
                CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
            }
        }
    }
}