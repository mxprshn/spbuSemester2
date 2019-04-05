using System;

namespace ParsingTree
{
    /// <summary>
    /// Class implementing the integer operand node in the parse tree of arithmetical expession. 
    /// </summary>
    public class Operand : Node
    {
        /// <summary>
        /// Creates a new operand node by its value.
        /// </summary>
        /// <param name="newValue">Value of the operand.</param>
        public Operand(int newValue)
        {
            Value = newValue;
        }

        /// <summary>
        /// Integer value of the operand.
        /// </summary>
        public override int Value { get; }

        /// <summary>
        /// Prints the operand as its integer value.
        /// </summary>
        public override void Print() => Console.Write($"{Value}");
    }
}