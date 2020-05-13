namespace Parser
{
    /// <summary>
    /// Interface of nodes of arithmetic expression tree
    /// </summary>
    public interface INodeOfExpressionTree
    {
        /// <summary>
        /// Prints itself and its subtree
        /// </summary>
        void Print();

        /// <summary>
        /// Calculates subtree
        /// </summary>
        /// <returns>Result of arithmetic expression of the subtree</returns>
        int Calculate();

        /// <summary>
        /// Checks availibility of not full operators
        /// </summary>
        /// <returns>Has subtree not availibility operators or not</returns>
        bool Full();
    }
}
