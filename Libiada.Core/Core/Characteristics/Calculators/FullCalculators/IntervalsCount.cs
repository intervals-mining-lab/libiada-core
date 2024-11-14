namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Intervals count depending on link.
/// </summary>
public class IntervalsCount : IFullCalculator
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
    /// Intervals count in chain as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        CongenericCalculators.IntervalsCount calculator = new();

        int sum = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            sum += (int)calculator.Calculate(chain.CongenericChain(i), link);
        }

        return sum;
    }
}
