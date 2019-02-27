
namespace HashTable
{
    interface ISet
    {
        int Size { get; }
        bool Add(int value);
        bool Remove(int value);
        bool Exists(int value);
    }
}