using System;

namespace ParsingTree
{
    public class ParseTree
    {
        public Node Root { get; }

        public void Print()
        {
            Root.Print();
        }

        public int Value => Root.Value;

        public ParseTree(Node newRoot)
        {
            Root = newRoot;
        }
    }
}