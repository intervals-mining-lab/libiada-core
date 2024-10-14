namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Entropy.
/// Amount of information.
/// Amount of identifying information (average for one element).
/// Shannon's information.
/// Shannon's entropy.
/// </summary>
public class IdentificationInformation : IFullCalculator
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
    /// Count of identification informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        CongenericCalculators.IdentificationInformation identificationInformation = new();

        Alphabet alphabet = chain.Alphabet;
        double result = 0;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            result += identificationInformation.Calculate(chain.CongenericChain(i), link);
        }

        return result;
    }
}
