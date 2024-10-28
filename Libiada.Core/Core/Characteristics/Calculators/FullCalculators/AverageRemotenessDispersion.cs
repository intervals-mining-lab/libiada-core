namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Dispersion of average remoteness.
/// </summary>
public class AverageRemotenessDispersion : IFullCalculator
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

        CongenericCalculators.AverageRemoteness congenericAverageRemoteness = new();
        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();

        double result = 0;
        double g = new AverageRemoteness().Calculate(chain, link);
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
            double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(i), link);
            double gDelta = gj - g;
            result += gDelta * gDelta * nj / n;
        }

        return result;
    }
}
