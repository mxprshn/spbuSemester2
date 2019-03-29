using System;

namespace UniqueListWithExceptions
{
    public class UniqueList : List
    {
        public override void InsertFirst(int newValue)
        {
            if (Exists(newValue))
            {
                throw new ExistingElementInsertionException();
            }

            base.InsertFirst(newValue);
        }

        public override void InsertAfter(int newValue, int previousPosition)
        {
            if (Exists(newValue))
            {
                throw new ExistingElementInsertionException();
            }

            base.InsertAfter(newValue, previousPosition);
        }

        public void RemoveByValue(int value)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The list was empty.");
            }

            if (head.Value == value)
            {
                RemoveFirst();
                return;
            }

            var current = head.Next;
            var previous = head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    previous.Next = previous.Next.Next;
                    --Length;
                }

                previous = current;
                previous = current.Next;
            }
        }
    }
}
