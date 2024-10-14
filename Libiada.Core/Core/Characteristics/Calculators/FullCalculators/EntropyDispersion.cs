namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Entropy of Dispersion.
/// </summary>
public class EntropyDispersion : IFullCalculator
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
    /// Entropy dispersion <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        IdentificationInformation identificationInformation = new();
        IntervalsCount intervalsCount = new();

        double result = 0;
        double h = identificationInformation.Calculate(chain, link);
        int n = (int)intervalsCount.Calculate(chain, link);

        CongenericCalculators.IntervalsCount congenericIntervalsCount = new();
        CongenericCalculators.IdentificationInformation congenericIdentificationInformation = new();
        Alphabet alphabet = chain.Alphabet;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
            double hj = congenericIdentificationInformation.Calculate(chain.CongenericChain(i), link);
            double deltaH = hj - h;
            result += n == 0 ? 0 : nj / n * deltaH * deltaH;
        }

        return result;
    }
}
