using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Iterators;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Seekers.Converters
{
    /// <summary>
    /// Removes all occupancies of sequence
    /// </summary>
    public class SequenceCleaner : Filter
    {
        public SequenceCleaner(ComplexChain chain):base(chain)
        {
        }

        public int filterout(List<String> sequence)
        {
            int hits = 0;
            EndIterator iterator = null;
            iterator = new EndIterator(chain, sequence.Count, ISeeker.step);

            while (iterator.hasNext())
            {
                if (iterator.next().Equals(sequence))
                {
                    chain.Remove(iterator.position(), sequence.Count);
                    hits = hits + 1;
                }
            }
            return hits;
        } 
    }
}