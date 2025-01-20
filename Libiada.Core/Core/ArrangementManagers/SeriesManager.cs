namespace Libiada.Core.Core.ArrangementManagers;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The congeneric series manager.
/// </summary>
public class SeriesManager : IArrangementManager
{
    /// <summary>
    /// The series.
    /// </summary>
    private readonly List<(int start, int length)> series;

    /// <summary>
    /// Initializes series manager with given sequence.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public SeriesManager(CongenericSequence sequence)
    {
        series = [];
        for (int i = 1; i <= sequence.OccurrencesCount; i++)
        {
            series.Add(GetSeries(sequence, i));
        }
    }

    /// <summary>
    /// Gets series from congeneric sequence.
    /// </summary>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    public int[] GetArrangement(Link link)
    {
        if (series == null)
        {
            throw new Exception("Series manager is not initialized");
        }

        return series.Select(s => s.length).ToArray();
    }

    /// <summary>
    /// Gets series from given occurrence.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="occurrence">
    /// Occurrence index of the element.
    /// </param>
    /// <returns>
    /// The <see cref="(int, int)"/>.
    /// </returns>
    private (int start, int length) GetSeries(CongenericSequence sequence, int occurrence)
    {
        int counter = 0;
        int position = sequence.GetOccurrence(occurrence);
        while (!sequence[position + counter].Equals(NullValue.Instance()))
        {
            counter++;
        }

        return (position, counter);
    }
}
