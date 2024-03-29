﻿namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness dispersion by intervals lengths.
/// </summary>
public class RemotenessDispersion : IFullCalculator
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
            intervals.AddRange(chain.CongenericChain(i).GetArrangement(link));
        }

        if (intervals.Count == 0)
        {
            return 0;
        }

        Dictionary<int, int> intervalsDictionary = intervals
                                 .GroupBy(i => i)
                                 .ToDictionary(i => i.Key, i => i.Count());

        IntervalsCount intervalsCount = new();
        GeometricMean geometricMean = new();

        double result = 0;
        double gDelta = geometricMean.Calculate(chain, link);
        double n = intervalsCount.Calculate(chain, link);

        foreach ((int interval, int count) in intervalsDictionary)
        {
            double centeredRemoteness = Math.Log(interval, 2) - Math.Log(gDelta, 2);
            result += centeredRemoteness * centeredRemoteness * count / n;
        }

        return result;
    }
}
