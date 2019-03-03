
namespace ModifiedHashTable
{
    public class RollingHash : IHashFunction
    {
        public ulong Hash(string source)
        {
            ulong hashSum = 0;
            ulong powerBase = 1;

            foreach (ulong characterCode in source)
            {
                hashSum += powerBase * characterCode;
                powerBase *= 53;
            }

            return hashSum;
        }
    }
}
