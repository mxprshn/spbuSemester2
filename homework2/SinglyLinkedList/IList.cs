
namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void Insert(int newValue);
        void InsertAfter(int newValue, int previousPosition);
        void InsertBefore(int newValue, int nextPosition);
        void Remove();
        void RemoveAfter(int previousPosition);
        void RemoveBefore(int nextPosition);
        int this[int position] { get; set; }
    }
}
