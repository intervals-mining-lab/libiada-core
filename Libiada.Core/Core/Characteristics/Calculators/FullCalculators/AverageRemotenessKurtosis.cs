namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness kurtosis.
/// </summary>
public class AverageRemotenessKurtosis : IFullCalculator
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
        AverageRemoteness averageRemoteness = new();
        IntervalsCount intervalsCount = new();

        double result = 0;
        double g = averageRemoteness.Calculate(chain, link);
        int n = (int)intervalsCount.Calculate(chain, link);
        if (n == 0)
        {
            return 0;
        }

        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();
        CongenericCalculators.AverageRemoteness congenericAverageRemoteness = new();
        Alphabet alphabet = chain.Alphabet;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
            double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(i), link);
            double delta = gj - g;
            result += delta * delta * delta * delta * nj / n;
        }

        return result;
    }
}
