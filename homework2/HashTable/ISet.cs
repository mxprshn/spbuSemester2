
namespace HashTable
{
    interface ISet
    {
        int Size { get; }
        void Add(int value);
        void Remove(int value);
        bool Exists(int value);
    }
}
