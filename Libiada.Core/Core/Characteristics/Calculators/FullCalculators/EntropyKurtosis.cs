namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The entropy kurtosis.
/// </summary>
public class EntropyKurtosis : IFullCalculator
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
    /// Entropy Kurtosis <see cref="double"/> value.
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
            result += deltaH * deltaH * deltaH * deltaH * nj / n;
        }

        return result;
    }
}
