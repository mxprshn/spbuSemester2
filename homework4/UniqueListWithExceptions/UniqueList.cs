
namespace UniqueListWithExceptions
{
    public class UniqueList : List
    {
        public override void InsertFirst(string newValue)
        {
            if (Exists(newValue))
            {
                throw new ExistingElementInsertionException();
            }

            base.InsertFirst(newValue);
        }

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