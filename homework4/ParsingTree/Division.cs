
namespace ParsingTree
{
    /// <summary>
    /// Class implementing the node of division in the parse tree of arithmetical expession. 
    /// </summary>
    public sealed class Division : Operation
    {
        /// <summary>
        /// The quotient of left and right children.
        /// </summary>
        public override int Value => Left.Value / Right.Value;

        /// <summary>
        /// Symbol used in printing the node.
        /// </summary>
        public override char OperationSymbol { get; } = '/';
    }
}
