
namespace StackCalculator
{
    class LStack : IStack
    {
        private class StackElement
        {
            public int Data { get; }
            public StackElement Next { get; }

            public StackElement(int data, StackElement next)
            {
                Data = data;
                Next = next;
            }
        }

        private StackElement head = null;
        public bool IsEmpty => head == null;

        public void Push(int data)
        {
            head = new StackElement(data, head);
        }

        public int Pop(out bool isSuccessful)
        {
            var result = Peek(out isSuccessful);

            if (isSuccessful)
            {
                head = head.Next;
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
            return head.Data;
        }
    }
}
