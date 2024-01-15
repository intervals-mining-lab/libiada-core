namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The average length of word (element) in sequence.
/// </summary>
public class AverageWordLength : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Average word length in <see cref="double"/> value.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        int chainLength = chain.Length;
        int sum = 0;

        for (int i = 0; i < chainLength; i++)
        {
            sum += ((ValueString)chain[i]).Value.Length;
        }

        return sum / (double)chainLength;
    }
}
