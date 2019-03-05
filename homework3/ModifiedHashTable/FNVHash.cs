
namespace ModifiedHashTable
{
    /// <summary>
    /// Class containing FNV hash function implementation.
    /// </summary>
    public class FNVHash : IHashFunction
    {
        private const ulong OffsetBasis = 14695981039346656037;
        private const ulong FNVPrime = 1099511628211;

        /// <summary>
        /// Computes a hash code for a string value.
        /// </summary>
        /// <param name="source">A string value to be hashed.</param>
        /// <returns>Hash code for the string.</returns>
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
