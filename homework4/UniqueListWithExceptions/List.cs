
namespace UniqueListWithExceptions
{
    /// <summary>
    /// Class implementing linked list data structure which contains string elements.
    /// </summary>
    public class List : IList
    {
        private class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }

            public Node(string newValue, Node newNext = null)
            {
                Value = newValue;
                Next = newNext;
            }
        }

        private Node head;

        /// <summary>
        /// Number of elements in the list.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Existence of elements in the list.
        /// </summary>
        public bool IsEmpty => head == null;

        private Node FindNode(int position)
        {
            if (IsEmpty)
            {
                throw new EmptyListOperationException();
            }

            if (position < 0 || position >= Length)
            {
                throw new IncorrectIndexException();
            }

            var temp = head;

            for (var i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }

            return temp;
        }

        /// <summary>
        /// Inserts a new element at the beginning of the list.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        public virtual void InsertFirst(string newValue)
        {
            head = new Node(newValue, head);
            ++Length;
        }

        /// <summary>
        /// Inserts a new element after another.
        /// </summary>
        /// <param name="newValue">A string value to insert.</param>
        /// <param name="previousPosition">Position of the previous element.</param>
        /// <exception cref="IncorrectIndexException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        public virtual void InsertAfter(string newValue, int previousPosition)
        {
            var previousNode = FindNode(previousPosition);
            previousNode.Next = new Node(newValue, previousNode.Next);
            ++Length;         
        }

        /// <summary>
        /// Removes the first element of the list.
        /// </summary>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        public void RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new EmptyListOperationException();
            }

            head = head.Next;
            --Length;
        }

        /// <summary>
        /// Removes an element of the list from particular position.
        /// </summary>
        /// <param name="position">Position of the element to remove.</param>
        /// <exception cref="IncorrectIndexException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        public void Remove(int position)
        {
            if (position == 0)
            {
                RemoveFirst();
                return;
            }

            if (position == Length)
            {
                throw new IncorrectIndexException();
            }

            var previousNode = FindNode(position - 1);
            previousNode.Next = previousNode.Next.Next;
            --Length;
        }

        /// <summary>
        /// Removes all the elements with particular value from the list.
        /// </summary>
        /// <param name="value">Value of the element to remove.</param>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        /// <exception cref="NotExistingElementRemovalException">Thrown when the value doesn't exist.</exception>
        public void Remove(string value)
        {
            if (IsEmpty)
            {
                throw new EmptyListOperationException();
            }

            if (head.Value == value)
            {
                RemoveFirst();
                return;
            }

            var current = head;
            var wasRemoved = false;

            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    --Length;
                    wasRemoved = true;
                }

                current = current.Next;
            }

            if (!wasRemoved)
            {
                throw new NotExistingElementRemovalException();
            }
        }

        /// <summary>
        /// Gets/sets an element on particular position.
        /// </summary>
        /// <param name="position">Position of the element to get/set.</param>
        /// <returns>A string element on </returns>
        /// <exception cref="IncorrectIndexException">Thrown when the parameter doesn't 
        /// match with any existing position.</exception>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        public virtual string this[int position]
        {
            get => FindNode(position).Value;

            set => FindNode(position).Value = value;
        }

        /// <summary>
        /// Checks a value for existence in the list.
        /// </summary>
        /// <param name="value">Value of the element to check for existence.</param>
        /// <returns>True if the value found, False otherwise.</returns>
        public bool Exists(string value)
        {
            var temp = head;

            while (temp != null)
            {
                if (temp.Value == value)
                {
                    return true;
                }

                temp = temp.Next;
            }

            return false;
        }

        /// <summary>
        /// Finds the position of an element by its value.
        /// </summary>
        /// <param name="value">A string value to find.</param>
        /// <returns>Index of the element's position.</returns>
        /// <exception cref="EmptyListOperationException">Thrown when the list is empty.</exception>
        /// <exception cref="NotExistingElementRequestException">Thrown when the value doesn't exist.</exception>
        public int FindPosition(string value)
        {
            if (IsEmpty)
            {
                throw new EmptyListOperationException();
            }

            var temp = head;

            for (var i = 0; i < Length; ++i)
            {
                if (temp.Value == value)
                {
                    return i;
                }

                temp = temp.Next;
            }

            throw new NotExistingElementRequestException();
        }
    }
}