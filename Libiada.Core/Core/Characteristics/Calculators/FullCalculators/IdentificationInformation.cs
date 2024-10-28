namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Entropy.
/// Amount of information.
/// Amount of identifying information (average for one element).
/// Shannon's information.
/// Shannon's entropy.
/// Calculated here using intervals count and arithmetic mean interval.
/// </summary>
public class IdentificationInformation : IFullCalculator
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
    /// Count of identification informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double n = new IntervalsCount().Calculate(chain, link);
        if (n == 0) return 0;

        CongenericCalculators.ArithmeticMean meanCalculator = new();
        CongenericCalculators.IntervalsCount counter = new();

        double result = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = counter.Calculate(chain.CongenericChain(i), link);
            double arithmeticMean = meanCalculator.Calculate(chain.CongenericChain(i), link);
            result += (nj / n) * Math.Log2(arithmeticMean);
        }

        return result;
    }
}
