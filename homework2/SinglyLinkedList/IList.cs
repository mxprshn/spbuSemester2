
namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void Insert(int newValue);
        void InsertBefore(int newValue, int nextPosition);
        void RemoveLast();
        void Remove(int position);
        int this[int position] { get; set; }
        bool Exists(int value, out int position);
    }
}
