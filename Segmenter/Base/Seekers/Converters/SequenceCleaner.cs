namespace Segmenter.Base.Seekers.Converters
{
    using System.Collections.Generic;

    using Segmenter.Base.Iterators;
    using Segmenter.Base.Sequencies;

    /// <summary>
    /// Removes all occupancies of sequence
    /// </summary>
    public class SequenceCleaner : Filter
    {
        public SequenceCleaner(ComplexChain chain)
            : base(chain)
        {
        }

        public int FilterOut(List<string> sequence)
        {
            int hits = 0;
            EndIterator iterator;
            iterator = new EndIterator(this.Chain, sequence.Count, Interfaces.Seeker.Step);

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
                    this.Chain.Remove(iterator.Position(), sequence.Count);
                    hits = hits + 1;
                }
            }

            return hits;
        }
    }
}