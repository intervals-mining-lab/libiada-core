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
        List<int> intervals = [];
        Alphabet alphabet = chain.Alphabet;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            intervals.AddRange(chain.CongenericChain(i).GetArrangement(link).ToList());
        }

        if (intervals.Count == 0)
        {
            return 0;
        }

        List<int> uniqueIntervals = intervals.Distinct().ToList();

        IntervalsCount intervalsCount = new();
        GeometricMean geometricMean = new();

        double result = 0;
        double gDelta = geometricMean.Calculate(chain, link);
        double n = intervalsCount.Calculate(chain, link);

        foreach (int kDelta in uniqueIntervals)
        {
            double centeredRemoteness = Math.Log(kDelta, 2) - Math.Log(gDelta, 2);
            result += centeredRemoteness * centeredRemoteness * centeredRemoteness * intervals.Count(interval => interval == kDelta) / n;
        }

        return result;
    }
}
