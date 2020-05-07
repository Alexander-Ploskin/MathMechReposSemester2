﻿namespace Parser
{
    /// <summary>
    /// Implements operator nodes of tree
    /// </summary>
    abstract class Operator : INodeOfExpressionTree
    {
        public Operator Parent { get; set; }
        protected INodeOfExpressionTree leftChild = null;
        protected INodeOfExpressionTree rightChild = null;

        /// <summary>
        /// Prints subtrees
        /// </summary>
        public virtual void Print()
        {
            if (leftChild != null)
            {
                leftChild.Print();
            }
            if (rightChild != null)
            {
                rightChild.Print();
            }
        }

        /// <summary>
        /// Calculate subtree
        /// </summary>
        /// <returns>Result of calculating</returns>
        public abstract int Calculate();

        /// <summary>
        /// Add new child to node
        /// </summary>
        /// <param name="newChild">New child of node</param>
        /// <exception cref="FullNodeException">Throws if can't add new child</exception>
        /// <returns>Reference to new child</returns>
        public Operator AddChildAndMove(Operator newChild)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                newChild.Parent = this;
                return newChild;
            }
            if (rightChild == null)
            {
                rightChild = newChild;
                newChild.Parent = this;
                return newChild;
            }
            throw new FullNodeException();
        }

        /// <summary>
        /// Checks is children are null or not full subtrees
        /// </summary>
        public bool Full()
        {
            if (rightChild == null || leftChild == null)
            {
                return false;
            }

            return rightChild.Full() && leftChild.Full();
        }

        /// <summary>
        /// Add child
        /// </summary>
        /// <param name="newChild">New child of node</param>
        public void AddChild(Number newChild)
        {
            if (leftChild == null)
            {
                leftChild = newChild;
                return;
            }
            if (rightChild == null)
            {
                rightChild = newChild;
                return;
            }
            throw new FullNodeException();
        }

    }
}