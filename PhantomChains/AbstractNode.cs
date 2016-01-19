namespace PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Tree node interface.
    /// </summary>
    public abstract class AbstractNode
    {
        /// <summary>
        /// The children.
        /// </summary>
        protected readonly List<TreeNode> Children = new List<TreeNode>();

        /// <summary>
        /// Gets or sets count of children elements.
        /// </summary>
        public ulong Volume { get; protected set; }

        /// <summary>
        /// Gets or sets the level of element in tree.
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        protected int StartPosition { get; set; }

        /// <summary>
        /// Interface of recursive method decrementing variations of current branch.
        /// Also decreases variants count of current node by 1. Called after generation of another value.
        /// </summary>
        /// <returns>
        /// Recursion flag for children. 
        /// If true further validation is required. 
        /// If false no further validation is required. 
        /// </returns>
        public abstract bool Decrement();

        /// <summary>
        /// Searcheck child element by its index.
        /// </summary>
        /// <param name="index">
        /// Index of child element.
        /// </param>
        /// <returns>
        /// Child element as <see cref="TreeNode"/>.
        /// </returns>
        public TreeNode GetChild(int index)
        {
            return Children[index];
        }

        /// <summary>
        /// Choosing which child will generate next element of sequence.
        /// </summary>
        /// <param name="result">
        /// Intermediate result.
        /// </param>
        /// <param name="generator">
        /// Random numbers generator.
        /// </param>
        /// <param name="table">
        /// Phantom sequence parameters table.
        /// </param>
        protected void Find(BaseChain result, IGenerator generator, PhantomTable table)
        {
            // if not leaf node
            if (Children.Count != 0)
            {
                double val = generator.Next();
                ulong curVal = 0;
                foreach (TreeNode child in Children)
                {
                    curVal += child.Volume;
                    if (val <= ((double)curVal / Volume))
                    {
                        child.FillChain(result, generator, table);
                        return;
                    }
                }
            }
            else
            {
                // if there is no children nodes then generation is done and decrement procedure is started
                Decrement();
            }
        }
    }
}
