
namespace ModifiedHashTable
{
    public class FNVHash : IHashFunction
    {
        private const ulong OffsetBasis = 14695981039346656037;
        private const ulong FNVPrime = 1099511628211;

        public ulong Hash(string source)
        {
            ulong hashSum = OffsetBasis;

            foreach (ulong characterCode in source)
            {
                hashSum *= FNVPrime;
                hashSum ^= characterCode;
            }

            return hashSum;
        }
    }
}
