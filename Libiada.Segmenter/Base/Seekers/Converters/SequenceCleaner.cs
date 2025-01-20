namespace Libiada.Segmenter.Base.Seekers.Converters;

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
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public SequenceCleaner(ComplexSequence sequence)
        : base(sequence)
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
        iterator = new EndIterator(Sequence, sequence.Count, Interfaces.Seeker.Step);

        while (iterator.HasNext())
        {
            List<string> temp = iterator.Next();
            bool sequencesEquals = sequence.Count == temp.Count;
            for (int i = 0; i < sequence.Count; i++)
            {
                if (temp[i] != sequence[i])
                {
                    sequencesEquals = false;
                    // TODO: check if break is missing
                }
            }

            if (sequencesEquals)
            {
                Sequence.Remove(iterator.Position(), sequence.Count);
                hits++;
            }
        }

        return hits;
    }
}
