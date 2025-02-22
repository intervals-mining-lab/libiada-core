namespace Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// The accordance intervals manager.
/// </summary>
public class AccordanceIntervalsManager
{
   /// <summary>
    /// The sequence length.
    /// </summary>
    public readonly int Length;

    /// <summary>
    /// First accordance  intervals.
    /// </summary>
    public readonly List<int> FilteredFirstIntervals = [];

    /// <summary>
    /// Second accordance intervals.
    /// </summary>
    public readonly List<int> FilteredSecondIntervals = [];

    /// <summary>
    /// First element occurrences count.
    /// </summary>
    public readonly int FirstOccurrencesCount;

    /// <summary>
    /// Second element occurrences count.
    /// </summary>
    public readonly int SecondOccurrencesCount;

    /// <summary>
    /// The first sequence.
    /// </summary>
    private readonly CongenericSequence firstSequence;

    /// <summary>
    /// The second sequence.
    /// </summary>
    private readonly CongenericSequence secondSequence;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccordanceIntervalsManager"/> class.
    /// </summary>
    /// <param name="firstSequence">
    /// The first sequence.
    /// </param>
    /// <param name="secondSequence">
    /// The second sequence.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    public AccordanceIntervalsManager(CongenericSequence firstSequence, CongenericSequence secondSequence, Link link)
    {
        this.firstSequence = firstSequence;
        this.secondSequence = secondSequence;
        Length = firstSequence.Length;
        FirstOccurrencesCount = firstSequence.OccurrencesCount;
        SecondOccurrencesCount = secondSequence.OccurrencesCount;

        FillAccordanceIntervals(link);
    }

    /// <summary>
    /// The fill accordance intervals.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    private void FillAccordanceIntervals(Link link)
    {
        if (link != Link.End)
        {
            throw new NotImplementedException();
        }

        int[] firstIntervals = firstSequence.GetArrangement(link);
        int[] secondIntervals = secondSequence.GetArrangement(link);

        for (int i = 1; i <= FirstOccurrencesCount; i++)
        {
            int firstPosition = firstSequence.GetOccurrence(i);
            int nextFirstPosition = firstSequence.GetOccurrence(i + 1) == -1 ? Length : firstSequence.GetOccurrence(i + 1);
            for (int j = 1; j <= secondSequence.OccurrencesCount; j++)
            {
                int secondOccurrence = secondSequence.GetOccurrence(j);
                if (secondOccurrence >= firstPosition && secondOccurrence < nextFirstPosition)
                {
                    FilteredFirstIntervals.Add(firstIntervals[i - 1]);
                    FilteredSecondIntervals.Add(secondIntervals[j - 1]);
                    break;
                }
            }
        }
    }
}
