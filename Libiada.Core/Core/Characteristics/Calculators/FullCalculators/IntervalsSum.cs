namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sum of intervals lengths depending on link.
/// </summary>
public class IntervalsSum : IFullCalculator
{
    /// <summary>
    /// Sum of intervals lengths in all congeneric sequences of complete sequence.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// Intervals sum as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        var calculator = new CongenericCalculators.IntervalsSum();

        Alphabet alphabet = chain.Alphabet;
        int sum = 0;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            sum += (int)calculator.Calculate(chain.CongenericChain(i), link);
        }

        return sum;
    }
}
