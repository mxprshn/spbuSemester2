
namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void InsertFirst(string newValue);
        void InsertAfter(string newValue, int previousPosition);
        void RemoveFirst();
        void Remove(int position);
        string this[int position] { get; set; }
        bool Exists(string value);
        int FindPosition(string value);
    }
}
