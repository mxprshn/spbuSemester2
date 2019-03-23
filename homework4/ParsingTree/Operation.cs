using System;

namespace ParsingTree
{
    /// <summary>
    /// Class representing the operation node in the parse tree of arithmetical expression.
    /// </summary>
    public abstract class Operation : Node
    {
        /// <summary>
        /// Symbol used in printing the node.
        /// </summary>
        public abstract char OperationSymbol { get; }

        /// <summary>
        /// Prints the node in the following format: (<OperationSymbol> <operand> <operand>).
        /// </summary>
        public override void Print()
        {
            Console.Write($"({OperationSymbol} ");
            Left.Print();
            Console.Write(" ");
            Right.Print();
            Console.Write(")");
        }
    }
}
