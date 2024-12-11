namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Entropy.
/// Equals to Shannon's entropy when cyclic bindind is used.
/// Amount of information.
/// Amount of identifying informations (average for one element).
/// Calculated here using intervals count and arithmetic mean interval.
/// </summary>
public class IdentifyingInformation : IFullCalculator
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
    /// Count of identifying informations as <see cref="double"/>.
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
            double arithmeticMean = meanCalculator.Calculate(chain.CongenericChain(i), link);
            if (arithmeticMean == 0) continue;

            double nj = counter.Calculate(chain.CongenericChain(i), link);
            
            result += (nj / n) * Math.Log2(arithmeticMean);
        }

        return result;
    }
}
