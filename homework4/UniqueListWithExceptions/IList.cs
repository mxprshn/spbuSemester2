
namespace UniqueListWithExceptions
{
    /// <summary>
    /// Interface of linked list data structure which contains string elements.
    /// </summary>
    public interface IList
    {
        /// <summary>
        /// Number of elements in the list.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Existence of elements in the list.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Inserts a new element at the beginning of the list.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        void InsertFirst(string newValue);

        /// <summary>
        /// Inserts a new element after another.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        /// <param name="previousPosition">Position of the previous element.</param>
        void InsertAfter(string newValue, int previousPosition);

        /// <summary>
        /// Removes the first element of the list.
        /// </summary>
        void RemoveFirst();

        /// <summary>
        /// Removes an element of the list from particular position.
        /// </summary>
        /// <param name="position">Position of the element to remove.</param>
        void Remove(int position);

        /// <summary>
        /// Removes all the elements with particular value from the list.
        /// </summary>
        /// <param name="value">Value of the element to remove.</param>
        void Remove(string value);

        /// <summary>
        /// Gets/sets an element on particular position.
        /// </summary>
        /// <param name="position">Position of the element to get/set.</param>
        /// <returns>A string element on </returns>
        string this[int position] { get; set; }

        /// <summary>
        /// Checks a value for existence in the list.
        /// </summary>
        /// <param name="value">A string value to check for existence.</param>
        /// <returns>True if the value found, False otherwise.</returns>
        bool Exists(string value);

        /// <summary>
        /// Finds the position of an element by its value.
        /// </summary>
        /// <param name="value">Value of the element to find.</param>
        /// <returns>Index of the element's position if it was found, -1 otherwise.</returns>
        int FindPosition(string value);
    }
}