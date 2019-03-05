
namespace ModifiedHashTable
{
    /// <summary>
    /// Class containing rolling hash function implementation.
    /// </summary>
    public class RollingHash : IHashFunction
    {
        /// <summary>
        /// Computes a hash code for a string value.
        /// </summary>
        /// <param name="source">A string value to be hashed.</param>
        /// <returns>Hash code for the string.</returns>
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
