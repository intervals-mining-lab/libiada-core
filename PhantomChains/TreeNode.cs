namespace PhantomChains
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Variants tree node.
    /// </summary>
    public class TreeNode : AbstractNode
    {
        /// <summary>
        /// The id.
        /// </summary>
        private readonly IBaseObject id;

        /// <summary>
        /// The parent.
        /// </summary>
        private readonly AbstractNode parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="parent">
        /// Parent node.
        /// </param>
        /// <param name="content">
        /// Content of the this node.
        /// </param>
        /// <param name="table">
        /// Parameters table.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if parent is null.
        /// </exception>
        public TreeNode(AbstractNode parent, IBaseObject content, PhantomTable table)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent", "Parent node is null");
            }

            this.parent = parent;
            Level = this.parent.Level + 1;
            Volume = table[Level + 1].Volume;
            id = content;
            StartPosition = table.StartPositions[Level];
        }

        /// <summary>
        /// Recursive method decrementing variations of current branch.
        /// Also decreases variants count of current node by 1. Called after generation of another value.
        /// </summary>
        /// <returns>
        /// Recursion flag for children. 
        /// If true further validation is required. 
        /// If false no further validation is required. 
        /// </returns>
        public override bool Decrement()
        {
            Volume--;
            bool flag = parent.Decrement();
            if (flag)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i].Volume == 0)
                    {
                        Children.RemoveAt(i);
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Method adds new element into generated sequence.
        /// And calls the same method of one of the children if sequence is incomplete.
        /// </summary>
        /// <param name="result">
        /// Generated sequence.
        /// </param>
        /// <param name="generator">
        /// Random number generator.
        /// </param>
        /// <param name="table">
        /// Parameters table.
        /// </param>
        public void FillChain(BaseChain result, IGenerator generator, PhantomTable table)
        {
            if ((table.Length != (Level + 2)) && (Children.Count == 0))
            {
                ValuePhantom temp = table[Level + 2].Content;
                for (int i = 0; i < temp.Cardinality; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], table));
                }
            }

            if ((id is BaseChain) || (id is ValueString))
            {
                string amino = id.ToString();
                for (int k = 0; k < amino.Length; k++)
                {
                    result[StartPosition + k] = new ValueString(amino[k]);
                }
            }
            else
            {
                result[StartPosition] = id;
            }

            Find(result, generator, table);
        }
    }
}
