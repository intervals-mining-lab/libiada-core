namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Seuqnece's depth characteristic calculator.
/// </summary>
public class Depth : IFullCalculator
{
    /// <summary>
    /// Calculated as base 2 logarithm of multiplication
    /// of intervals between nearest elements
    /// in congeneric sequence.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Average remoteness <see cref="double"/> value.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        CongenericCalculators.Depth calculator = new();

        double result = 0;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result += calculator.Calculate(chain.CongenericChain(i), link);
        }

        return result;
    }
}
