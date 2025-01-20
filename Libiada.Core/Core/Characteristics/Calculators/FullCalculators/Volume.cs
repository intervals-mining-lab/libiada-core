namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using System.Numerics;

/// <summary>
/// Volume of sequence.
/// </summary>
public class Volume : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// Volume characteristic of the sequence as <see cref="double"/>.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        CongenericCalculators.Volume calculator = new();
        
        BigInteger result = 1;
        int alphabetCardinality = sequence.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result *= (BigInteger)calculator.Calculate(sequence.CongenericSequence(i), link);
        }

        return (double)result;
    }
}
