using System;

namespace ParsingTree
{
    public sealed class Division : Operation
    {
        public override int Value => Left.Value / Right.Value;
        public override char OperationSymbol { get; } = '/';
    }
}
