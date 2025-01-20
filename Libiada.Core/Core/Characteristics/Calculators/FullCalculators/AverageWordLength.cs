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
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Average word length in <see cref="double"/> value.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        int sum = 0;
        int sequenceLength = sequence.Length;
        for (int i = 0; i < sequenceLength; i++)
        {
            sum += ((ValueString)sequence[i]).Value.Length;
        }

        return sum / (double)sequenceLength;
    }
}
