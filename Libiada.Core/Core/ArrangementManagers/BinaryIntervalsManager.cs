namespace Libiada.Core.Core.ArrangementManagers;

using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The relation interval manager.
/// </summary>
public class BinaryIntervalsManager
{
    /// <summary>
    /// First sequence element.
    /// </summary>
    public readonly IBaseObject FirstElement;

    /// <summary>
    /// Second sequence element.
    /// </summary>
    public readonly IBaseObject SecondElement;

    /// <summary>
    /// The first sequence.
    /// </summary>
    public readonly CongenericSequence FirstSequence;

    /// <summary>
    /// The second sequence.
    /// </summary>
    public readonly CongenericSequence SecondSequence;

    /// <summary>
    /// The elements pairs count.
    /// </summary>
    public readonly int PairsCount;

    /// <summary>
    /// The sequence length.
    /// </summary>
    public readonly int Length;

    /// <summary>
    /// Relation intervals.
    /// </summary>
    private readonly int[] relationIntervals;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryIntervalsManager"/> class.
    /// </summary>
    /// <param name="firstSequence">
    /// The first sequence.
    /// </param>
    /// <param name="secondSequence">
    /// The second sequence.
    /// </param>
    public BinaryIntervalsManager(CongenericSequence firstSequence, CongenericSequence secondSequence)
    {
        FirstElement = firstSequence.Element;
        SecondElement = secondSequence.Element;
        FirstSequence = firstSequence;
        SecondSequence = secondSequence;
        Length = firstSequence.Length;

        PairsCount = FillPairsCount();
        relationIntervals = new int[PairsCount];
        FillIntervals();
    }

    /// <summary>
    /// Calculates ith interval for given occurrence of pair of elements in binary-congeneric sequence.
    /// </summary>
    /// <param name="occurrence">
    /// Occurrence number counted from one.
    /// </param>
    /// <returns>
    /// Interval length.
    /// </returns>
    public int GetBinaryInterval(int occurrence)
    {
        int firstElementFirstOccurrence = FirstSequence.GetOccurrence(occurrence);
        if (firstElementFirstOccurrence == -1)
        {
            return -1;
        }

        int secondElementOccurrence = SecondSequence.GetFirstAfter(firstElementFirstOccurrence);

        if (secondElementOccurrence == -1)
        {
            return -1;
        }

        int firstElementSecondOccurrence = FirstSequence.GetOccurrence(occurrence + 1);

        if (firstElementSecondOccurrence == -1)
        {
            firstElementSecondOccurrence = int.MaxValue;
        }

        if (secondElementOccurrence < firstElementSecondOccurrence)
        {
            return secondElementOccurrence - firstElementFirstOccurrence;
        }

        return -1;
    }

    /// <summary>
    /// The get first.
    /// </summary>
    /// <param name="entry">
    /// The entry.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int GetFirst(int entry)
    {
        return FirstSequence.GetOccurrence(entry);
    }

    /// <summary>
    /// Returns position of first occurrence of second element after given position.
    /// </summary>
    /// <param name="index">
    /// Starting index for search.
    /// </param>
    /// <returns>
    /// Position index or -1 if element after given position is not found.
    /// </returns>
    public int GetFirstAfter(int index)
    {
        for (int i = index; i < SecondSequence.Length; i++)
        {
            if (SecondSequence[i].Equals(SecondSequence.Element))
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// The get intervals.
    /// </summary>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    public int[] GetIntervals()
    {
        return (int[])relationIntervals.Clone();
    }

    /// <summary>
    /// The fill pairs count.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    private int FillPairsCount()
    {
        int counter = 0;

        ElementsCount elementCounter = new();
        int firstElementCount = (int)elementCounter.Calculate(FirstSequence);

        for (int i = 1; i <= firstElementCount; i++)
        {
            int binaryInterval = GetBinaryInterval(i);
            if (binaryInterval > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    /// <summary>
    /// The fill intervals.
    /// </summary>
    private void FillIntervals()
    {
        int counter = 0;
        for (int i = 1; i <= FirstSequence.OccurrencesCount; i++)
        {
            int binaryInterval = GetBinaryInterval(i);
            if (binaryInterval > 0)
            {
                relationIntervals[counter++] = binaryInterval;
            }
        }

        // Start = GetAfter(1);

        // End = GetAfter()
    }
}
