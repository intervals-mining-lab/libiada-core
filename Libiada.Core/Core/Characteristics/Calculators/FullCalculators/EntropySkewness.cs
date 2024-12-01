namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Asymmetry of the entropy in congeneric sequences. Third central moment.
/// </summary>
public class EntropySkewness : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// Calculated here using arithmetis mean interval and 
    /// intervals count instead of elements frequency 
    /// based on geometric mean interval formula.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Entropy skewness <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double n = new IntervalsCount().Calculate(chain, link);
        if (n == 0) return 0;

        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();
        CongenericCalculators.IdentificationInformation congenericIdentificationInformation = new();

        double result = 0;
        double h = new IdentificationInformation().Calculate(chain, link);
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
            double hj = congenericIdentificationInformation.Calculate(chain.CongenericChain(i), link);
            double deltaH = hj - h;
            result += deltaH * deltaH * deltaH * nj / n;
        }

        return result;
    }
}
