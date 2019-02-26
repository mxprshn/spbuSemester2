
namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void InsertFirst(int newValue);
        void InsertAfter(int newValue, int previousPosition);
        void RemoveFirst();
        void Remove(int position);
        int this[int position] { get; set; }
        bool Exists(int value);
        int FindPosition(int value);
    }
}
