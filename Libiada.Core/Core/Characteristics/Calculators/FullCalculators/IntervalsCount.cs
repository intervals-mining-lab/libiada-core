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
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Intervals count in chain as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        var calculator = new CongenericCalculators.IntervalsCount();

        Alphabet alphabet = chain.Alphabet;
        int sum = 0;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            sum += (int)calculator.Calculate(chain.CongenericChain(i), link);
        }

        return sum;
    }
}
