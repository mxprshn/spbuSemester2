using System;

namespace ParsingTree
{
    public class ParseTree
    {
        private Node Root;

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