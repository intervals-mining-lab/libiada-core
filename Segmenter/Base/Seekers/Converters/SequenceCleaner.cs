namespace Segmenter.Base.Seekers.Converters
{
    using System.Collections.Generic;

    using Segmenter.Base.Iterators;
    using Segmenter.Base.Sequences;

    /// <summary>
    /// Removes all occupancies of sequence
    /// </summary>
    public class SequenceCleaner : Filter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceCleaner"/> class.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        public SequenceCleaner(ComplexChain chain)
            : base(chain)
        {
        }

        /// <summary>
        /// The filter out.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int FilterOut(List<string> sequence)
        {
            int hits = 0;
            EndIterator iterator;
            iterator = new EndIterator(Chain, sequence.Count, Interfaces.Seeker.Step);

            while (iterator.HasNext())
            {
                List<string> temp = iterator.Next();
                bool chainsEquals = sequence.Count == temp.Count;
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (temp[i] != sequence[i])
                    {
                        chainsEquals = false;
                    }
                }

                if (chainsEquals)
                {
                    Chain.Remove(iterator.Position(), sequence.Count);
                    hits = hits + 1;
                }
            }

            return hits;
        }
    }
}