namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Variance of remoteneses by intervals lengths.
/// </summary>
public class RemotenessVariance : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Remoteness variance <see cref="double"/> value.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double n = new IntervalsCount().Calculate(sequence, link);
        if (n == 0) return 0;

        List<int> intervals = [];
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            intervals.AddRange(sequence.CongenericSequence(i).GetArrangement(link));
        }

        // calcualting number of intervals of certain length
        Dictionary<int, int> intervalsDictionary = intervals
                                 .GroupBy(i => i)
                                 .ToDictionary(i => i.Key, i => i.Count());

        double result = 0;
        double g = new AverageRemoteness().Calculate(sequence, link);

        foreach ((int interval, int nk) in intervalsDictionary)
        {
            double centeredRemoteness = Math.Log2(interval) - g;
            result += centeredRemoteness * centeredRemoteness * nk / n;
        }

        return result;
    }
}
