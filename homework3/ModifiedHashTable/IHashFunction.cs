
namespace ModifiedHashTable
{
    /// <summary>
    /// Interface of hash function.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Computes a hash code for a string value.
        /// </summary>
        /// <param name="source">A string value to be hashed.</param>
        /// <returns>Hash code for the string.</returns>
        ulong Hash(string source);
    }
}