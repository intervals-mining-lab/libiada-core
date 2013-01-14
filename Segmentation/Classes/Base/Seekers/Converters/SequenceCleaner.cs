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

        public int FilterOut(List<String> sequence)
        {
            int hits = 0;
            EndIterator iterator = null;
            iterator = new EndIterator(Chain, sequence.Count, ISeeker.step);

            while (iterator.HasNext())
            {
                List<String> temp = iterator.Next();
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