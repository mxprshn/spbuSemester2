
namespace ModifiedHashTable
{
    interface ISet
    {
        int Size { get; }
        bool Add(string value);
        bool Remove(string value);
        bool Exists(string value);
    }
}