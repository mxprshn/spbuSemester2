using System;

namespace ParsingTree
{
    public class Operand : Node
    {
        public Operand(int newValue)
        {
            Value = newValue;
        }

        public override int Value { get; }

        public override void Print()
        {
            Console.Write($"{Value}");
        }
    }
}