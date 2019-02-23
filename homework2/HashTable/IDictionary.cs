
namespace HashTable
{
    interface IDictionary
    {
        void Insert(string key, string value);
        void Remove(string key);
        string GetValue(string key);
        bool Exists(string key);
    }
}
