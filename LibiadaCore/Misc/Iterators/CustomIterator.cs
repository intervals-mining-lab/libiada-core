namespace LibiadaCore.Misc.Iterators
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;

    /// <summary>
    /// The custom iterator.
    /// </summary>
    public class CustomIterator : IIterator
    {
        /// <summary>
        /// The starts.
        /// </summary>
        private readonly List<List<int>> starts;

        /// <summary>
        /// The lengthes.
        /// </summary>
        private readonly List<List<int>> lengthes;

        /// <summary>
        /// The source.
        /// </summary>
        private readonly AbstractChain source;

        /// <summary>
        /// The counter.
        /// </summary>
        private int counter = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomIterator"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="starts">
        /// The starts.
        /// </param>
        /// <param name="lengthes">
        /// The lengthes.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if arguments are invalid.
        /// </exception>
        public CustomIterator(AbstractChain source, List<List<int>> starts, List<List<int>> lengthes)
        {
            if (source == null || starts == null || lengthes == null)
            {
                throw new ArgumentException("Invalid iterator params.");
            }

            if (starts.Count != lengthes.Count)
            {
                throw new ArgumentException("Starts and lengthes arrays contains not equal amount of elements.");
            }

            for (int i = 0; i < starts.Count; i++)
            {
                if (starts[i].Count != lengthes[i].Count)
                {
                    throw new ArgumentException("Starts and lengthes inner arrays contains not equal amount of elements.");
                }
            }

            this.starts = starts;
            this.lengthes = lengthes;
            this.source = source;
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Next()
        {
            counter++;
            return counter < starts.Count;
        }

        /// <summary>
        /// The current.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractChain"/>.
        /// </returns>
        public AbstractChain Current()
        {
            var elements = new List<IBaseObject>();

            for (int i = 0; i < starts[counter].Count; i++)
            {
                for (int j = 0; j < lengthes[counter][i]; j++)
                {
                    elements.Add(source[starts[counter][i] + j]);
                }
            }

            return new Chain(elements);
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            counter = -1;
        }
    }
}
