using System;

namespace ParsingTree
{
    public abstract class Node
    {
        public abstract int Value { get; }
        public abstract void Print();
    }
}
