namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Iterators;

/// <summary>
/// Sadovsky cut length.
/// </summary>
public class CuttingLength : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Cut length as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        for (int length = 1; length <= sequence.Length; length++)
        {
            if (IsRecoveryPossible(sequence, length))
            {
                return length;
            }
        }

        return sequence.Length;
    }

    /// <summary>
    /// Method for checking if reconstruction of original sequence is possible.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="length">
    /// Length of L-gram.
    /// </param>
    /// <returns>
    /// true if sequence is recoverable form L-grams.
    /// </returns>
    private bool IsRecoveryPossible(AbstractSequence sequence, int length)
    {
        IteratorStart iterator = new(sequence, length, 1);
        Alphabet alphabet = [];

        while (iterator.Next())
        {
            if (alphabet.Contains(iterator.Current()))
            {
                return false;
            }

            alphabet.Add(iterator.Current());
        }

        return true;
    }
}
