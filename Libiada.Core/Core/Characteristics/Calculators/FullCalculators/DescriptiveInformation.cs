namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Mazur's descriptive information.
/// </summary>
public class DescriptiveInformation : IFullCalculator
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
    /// Count of descriptive informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        double n = new IntervalsCount().Calculate(chain, link);
        if (n == 0) return 1;

        CongenericCalculators.ArithmeticMean arithmeticMeanCalculator = new();
        CongenericCalculators.IntervalsCount intervalsCountCalculator = new();
        
        double result = 1;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            double nj = intervalsCountCalculator.Calculate(chain.CongenericChain(i), link);
            double arithmeticMean = arithmeticMeanCalculator.Calculate(chain.CongenericChain(i), link);
            result *= Math.Pow(arithmeticMean, nj/n);
        }

        return result;
    }
}
