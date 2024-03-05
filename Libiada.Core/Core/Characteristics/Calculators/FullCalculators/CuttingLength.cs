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
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Cut length as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        for (int length = 1; length <= chain.Length; length++)
        {
            if (IsRecoveryPossible(chain, length))
            {
                return length;
            }
        }

        return chain.Length;
    }

    /// <summary>
    /// Method for checking if reconstruction of original sequence is possible.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="length">
    /// Length of L-gram.
    /// </param>
    /// <returns>
    /// true if chain is recoverable form L-grams.
    /// </returns>
    private bool IsRecoveryPossible(AbstractChain chain, int length)
    {
        var iterator = new IteratorStart(chain, length, 1);
        var alphabet = new Alphabet();

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
