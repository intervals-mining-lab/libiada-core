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
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <returns>
    /// Volume characteristic of chain as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        CongenericCalculators.Volume calculator = new();
        
        BigInteger result = 1;
        int alphabetCardinality = chain.Alphabet.Cardinality;
        for (int i = 0; i < alphabetCardinality; i++)
        {
            result *= (BigInteger)calculator.Calculate(chain.CongenericChain(i), link);
        }

        return (double)result;
    }
}
