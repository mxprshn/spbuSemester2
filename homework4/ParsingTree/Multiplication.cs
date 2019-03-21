using System;

namespace ParsingTree
{
    public sealed class Multiplication : Operation
    {
        public override int Value => Left.Value * Right.Value;
        public override char OperationSymbol { get; } = '+';
    }
}