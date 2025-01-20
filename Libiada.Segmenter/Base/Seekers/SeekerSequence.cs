namespace Libiada.Segmenter.Base.Seekers;

using Segmenter.Interfaces;

/// <summary>
/// The seeker sequence.
/// </summary>
public class SeekerSequence : Seeker
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SeekerSequence"/> class.
    /// </summary>
    /// <param name="where">
    /// The where.
    /// </param>
    public SeekerSequence(IIterator where)
        : base(where)
    {
    }

    /// <summary>
    /// The seek.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int Seek(List<string> sequence)
    {
        result = [];
        while (iterator.HasNext())
        {
            List<string> curentSequence = iterator.Next();
            bool sequencesEquals = sequence.Count == curentSequence.Count;
            for (int i = 0; i < sequence.Count; i++)
            {
                if (curentSequence[i] != sequence[i])
                {
                    sequencesEquals = false;
                    // TODO: check if break is missing
                }
            }

            if (sequencesEquals)
            {
                result.Add(iterator.Position());
            }
        }

        iterator.Reset();
        return result.Count;
    }
}
