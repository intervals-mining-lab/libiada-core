namespace Libiada.Core.Core.ArrangementManagers;

using System.ComponentModel;

/// <summary>
/// The congeneric intervals manager.
/// </summary>
public class IntervalsManager : IArrangementManager
{
    /// <summary>
    /// Gets main intervals block
    /// without start, end or cycle link.
    /// </summary>
    private readonly int[] intervals;

    /// <summary>
    /// Gets or sets interval from start of chain to first element.
    /// </summary>
    private int Start { get; set; }

    /// <summary>
    /// Gets or sets interval from last element to end of chain.
    /// </summary>
    private int End { get; set; }

    /// <summary>
    /// The initialize.
    /// </summary>
    /// <param name="intervals">
    /// The intervals.
    /// </param>
    /// <param name="start">
    /// The start.
    /// </param>
    /// <param name="end">
    /// The end.
    /// </param>
    public IntervalsManager(int[] intervals, int start, int end)
    {
        this.intervals = intervals;
        Start = start;
        End = end;
    }

    /// <summary>
    /// The initialize.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if sequence is empty.
    /// </exception>
    public IntervalsManager(CongenericChain chain)
    {
        int[] positions = chain.Positions;
        int count = positions.Length;

        // if sequence is empty
        if (count == 0)
        {
            throw new ArgumentException("Sequence should not be empty", "chain");
        }

        intervals = new int[count - 1];
        FillIntervals(positions, chain.Length);
    }

    /// <summary>
    /// Method, returning intervals array by link.
    /// </summary>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// List of intervals.
    /// </returns>
    public int[] GetArrangement(Link link)
    {
        int[] result;
        switch (link)
        {
            case Link.None:
                result = new int[intervals.Length];
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i] = intervals[i];
                }

                return result;
            case Link.Start:
                result = new int[intervals.Length + 1];
                result[0] = Start;
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i + 1] = intervals[i];
                }

                return result;
            case Link.End:
                result = new int[intervals.Length + 1];
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i] = intervals[i];
                }

                result[result.Length - 1] = End;
                return result;
            case Link.Both:
                result = new int[intervals.Length + 2];
                result[0] = Start;
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i + 1] = intervals[i];
                }

                result[result.Length - 1] = End;
                return result;
            case Link.Cycle:
                result = new int[intervals.Length + 1];
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i] = intervals[i];
                }

                result[result.Length - 1] = Start + End - 1;
                return result;
            case Link.CycleStart:
                result = new int[intervals.Length + 1];
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i] = intervals[i];
                }

                result[result.Length - 1] = Start + End - 1;
                return result;
            case Link.CycleEnd:
                result = new int[intervals.Length + 1];
                result[0] = Start + End - 1;
                for (int i = 0; i < intervals.Length; i++)
                {
                    result[i + 1] = intervals[i];
                }

                return result;

            default:
                throw new InvalidEnumArgumentException(nameof(link), (int)link, typeof(Link));
        }
    }

    /// <summary>
    /// The fill intervals.
    /// </summary>
    /// <param name="positions">
    /// Not empty positions of congeneric sequence.
    /// </param>
    /// <param name="sequenceLength">
    /// Length of the sequence.
    /// </param>
    private void FillIntervals(int[] positions, int sequenceLength)
    {
        Start = positions[0] - (-1);

        for (int i = 0; i < intervals.Length; i++)
        {
            intervals[i] = positions[i + 1] - positions[i];
        }

        End = sequenceLength - positions[positions.Length - 1];
    }
}
