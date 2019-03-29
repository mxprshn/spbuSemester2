using System;

namespace UniqueListWithExceptions
{
    /// <summary>
    /// List class extension containing unique elements.
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Inserts a new element in the beginning of the list.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        /// <exception cref="ExistingElementInsertionException">Thrown when the value already exists.</exception>
        public override void InsertFirst(string newValue)
        {
            if (Exists(newValue))
            {
                throw new ExistingElementInsertionException();
            }

            base.InsertFirst(newValue);
        }

        /// <summary>
        /// Inserts a new element after another.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        /// <param name="previousPosition">Position of the previous element.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
        /// <exception cref="ExistingElementInsertionException">Thrown when the value already exists.</exception>
        public override void InsertAfter(string newValue, int previousPosition)
        {
            if (Exists(newValue))
            {
                throw new ExistingElementInsertionException();
            }

            base.InsertAfter(newValue, previousPosition);
        }
    }
}