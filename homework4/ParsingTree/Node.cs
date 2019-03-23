
namespace ParsingTree
{
    /// <summary>
    /// Class representing a general node in the parse tree of arithmetical expression.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// The left child of the node.
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// The right child of the node.
        /// </summary>
        public Node Right { get; set; }

        /// <summary>
        /// Integer value of the node.
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Prints the node to console.
        /// </summary>
        public abstract void Print();
    }
}
