using System;

namespace ParsingTree
{
    public abstract class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public abstract int Value { get; }
        public abstract void Print();
    }
}
