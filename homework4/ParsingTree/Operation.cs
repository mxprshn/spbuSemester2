using System;

namespace ParsingTree
{
    public abstract class Operation : Node
    {
        public abstract char OperationSymbol { get; }

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
