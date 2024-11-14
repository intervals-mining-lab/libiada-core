namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Asymmetry of average remotenesses in congeneric sequences. Third central moment.
/// </summary>
public class AverageRemotenessSkewness : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Average remoteness skewness <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {        
        double n = new IntervalsCount().Calculate(chain, link);
        if (n == 0) return 0;

        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();
        CongenericCalculators.AverageRemoteness congenericAverageRemoteness = new();

        double result = 0;
        double g = new AverageRemoteness().Calculate(chain, link);
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
            double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(i), link);
            double delta = gj - g;
            result += delta * delta * delta * nj / n;
        }

        return result;
    }
}
