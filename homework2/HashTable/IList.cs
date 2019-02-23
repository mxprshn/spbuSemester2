using System;

namespace SinglyLinkedList
{
    public interface IList
    {
        int Length { get; }
        bool IsEmpty { get; }
        void Insert(string key, string value);
        void InsertAfter(string key, string value, int previousPosition);
        void InsertBefore(string key, string value, int nextPosition);
        void Remove();
        void RemoveAfter(int previousPosition);
        void RemoveBefore(int nextPosition);
        Tuple<string, string> this[int position] { get; set; }
        string this[string key] { get; set; }
    }
}
