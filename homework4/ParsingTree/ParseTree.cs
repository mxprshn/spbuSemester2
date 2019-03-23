
namespace ParsingTree
{
    /// <summary>
    /// Class implementing the parse tree of arithmetical expression.
    /// </summary>
    public class ParseTree
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        private Node Root;

        /// <summary>
        /// Creates a new parse tree by the root node.
        /// </summary>
        /// <param name="newRoot">The root of the new tree.</param>
        public ParseTree(Node newRoot)
        {
            Root = newRoot;
        }

        /// <summary>
        /// Value of the tree expression.
        /// </summary>
        public int Value => Root.Value;

        /// <summary>
        /// Prints the tree in the following format: (<operation> <operand/subtree> <operand/subtree>).
        /// </summary>
        public void Print()
        {
            Root.Print();
        }
    }
}