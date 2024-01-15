namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Mazur's descriptive information.
/// </summary>
public class DescriptiveInformation : IFullCalculator
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
    /// Count of descriptive informations as <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        var calculator = new CongenericCalculators.DescriptiveInformation();

        Alphabet alphabet = chain.Alphabet;
        double result = 1;
        for (int i = 0; i < alphabet.Cardinality; i++)
        {
            result *= calculator.Calculate(chain.CongenericChain(i), link);
        }

        return result;
    }
}
