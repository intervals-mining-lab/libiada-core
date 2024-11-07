namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness skewness by intervals lengths.
/// </summary>
public class RemotenessSkewness : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Average remoteness dispersion <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double n = new IntervalsCount().Calculate(chain, link);
        if (n == 0) return 0;

        List<int> intervals = [];
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            intervals.AddRange(chain.CongenericChain(i).GetArrangement(link));
        }

        // calcualting number of intervals of certain length
        Dictionary<int, int> intervalsDictionary = intervals
                                 .GroupBy(i => i)
                                 .ToDictionary(i => i.Key, i => i.Count());

        double result = 0;
        double g = new AverageRemoteness().Calculate(chain, link);
        
        foreach ((int interval, int nk) in intervalsDictionary)
        {
            double centeredRemoteness = Math.Log(interval, 2) - g;
            result += centeredRemoteness * centeredRemoteness * centeredRemoteness * nk / n;
        }

        return result;
    }
}
