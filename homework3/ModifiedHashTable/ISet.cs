
namespace ModifiedHashTable
{
    /// <summary>
    /// Interface of set data structure, which contains unique string elements.
    /// </summary>
    public interface ISet
    {
        /// <summary>
        /// Number of elements in the set.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Adds a new string value to the set if it doesn't already exist.
        /// </summary>
        /// <param name="value">A string value to add.</param>
        /// <returns>True if the value didn't exist and was added, False if the value already exists.</returns>
        bool Add(string value);

        /// <summary>
        /// Removes a string value from the set if it exists there.
        /// </summary>
        /// <param name="value">A string value to remove.</param>
        /// <returns>True if the value existed and was removed, False if the value doesn't exist.</returns>
        bool Remove(string value);

        /// <summary>
        /// Checks a string value for existence in the set.
        /// </summary>
        /// <param name="value">A string value to check for existence.</param>
        /// <returns>True if the value exists, otherwise False.</returns>
        bool Exists(string value);
    }
}