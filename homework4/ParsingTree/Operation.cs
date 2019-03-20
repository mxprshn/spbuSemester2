using System;

namespace ParsingTree
{
    public abstract class Operation : Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
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
