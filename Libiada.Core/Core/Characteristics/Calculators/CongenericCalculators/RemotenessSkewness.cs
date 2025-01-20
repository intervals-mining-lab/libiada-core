namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The remoteness skewness.
/// </summary>
public class RemotenessSkewness : ICongenericCalculator
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
    /// Remoteness skewness <see cref="double"/> value.
    /// </returns>
    public double Calculate(CongenericSequence sequence, Link link)
    {
        int[] intervals = sequence.GetArrangement(link);            
        if (intervals.Length == 0) return 0;

        // calcualting number of intervals of certain length
        Dictionary<int, int> intervalsDictionary = intervals
                                                     .GroupBy(i => i)
                                                     .ToDictionary(i => i.Key, i => i.Count());

        double result = 0;
        double gDeltaLog = new AverageRemoteness().Calculate(sequence, link);
        double nj = new IntervalsCount().Calculate(sequence, link);

        foreach ((int interval, int nk) in intervalsDictionary)
        {
            double centeredRemoteness = Math.Log(interval, 2) - gDeltaLog;
            result += centeredRemoteness * centeredRemoteness * centeredRemoteness * nk / nj;
        }

        return result;
    }
}
