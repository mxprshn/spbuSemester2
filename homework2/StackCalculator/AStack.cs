using System;

namespace StackCalculator
{
    class AStack : IStack
    {
        private const int StartSize = 2;
        private int[] elements = new int[StartSize];
        private int pushPosition;
        public bool IsEmpty => pushPosition == 0;

        public void Push(int data)
        {
            if (pushPosition >= elements.Length)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            elements[pushPosition] = data;
            ++pushPosition;
        }

        public int Pop(out bool isSuccessful)
        {
            var result = Peek(out isSuccessful);

            if (isSuccessful)
            {
                elements[--pushPosition] = 0;
            }

            return result;
        }

        public int Peek(out bool isSuccessful)
        {
            if (IsEmpty)
            {
                isSuccessful = false;
                return -1;
            }

            isSuccessful = true;
            return elements[pushPosition - 1];
        }

        public void Clear()
        {
            Array.Clear(elements, 0, pushPosition);
            pushPosition = 0;
        }
    }
}
