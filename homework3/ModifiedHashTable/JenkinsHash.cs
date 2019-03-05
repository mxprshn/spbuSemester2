
namespace ModifiedHashTable
{
    /// <summary>
    /// Class containing Jenkins hash function implementation.
    /// </summary>
    public class JenkinsHash : IHashFunction
    {
        /// <summary>
        /// Computes a hash code for a string value.
        /// </summary>
        /// <param name="source">A string value to be hashed.</param>
        /// <returns>Hash code for the string.</returns>
        public ulong Hash(string source)
        {
            ulong hashSum = 0;

            foreach(ulong characterCode in source)
            {
                hashSum += characterCode;
                hashSum += hashSum << 10;
                hashSum ^= hashSum >> 6;
            }

            hashSum += hashSum << 3;
            hashSum ^= hashSum >> 11;
            hashSum += hashSum << 15;

            return hashSum;
        }
    }
}
