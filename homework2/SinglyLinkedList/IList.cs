
namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void Insert(int newValue);
        bool InsertBefore(int newValue, int nextPosition);
        bool RemoveLast();
        bool Remove(int position);
        int this[int position] { get; set; }
        bool Exists(int value, out int position);
    }
}
