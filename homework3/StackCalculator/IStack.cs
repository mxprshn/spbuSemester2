
namespace StackCalculator
{
    public interface IStack
    {
        bool IsEmpty { get; }
        void Push(int data);
        int Pop(out bool isSuccessful);
        int Peek(out bool isSuccessful);
        void Clear();
    }
}
