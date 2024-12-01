namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Calculator that also stores the link.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LinkedFullCalculator"/> class.
/// </remarks>
/// <param name="type">
/// Calculator type.
/// </param>
/// <param name="link">
/// The link to use for calculation.
/// </param>
public class LinkedCongenericCalculator(CongenericCharacteristic type, Link link)
{
    /// <summary>
    /// The link to use for calculation.
    /// </summary>
    private readonly Link link = link;

    /// <summary>
    /// Actual characteristic calculator.
    /// </summary>
    private readonly ICongenericCalculator calculator = CongenericCalculatorsFactory.CreateCalculator(type);

    /// <summary>
    /// Calculates characteristic value with given calculator and link.
    /// </summary>
    /// <param name="sequence">
    /// The congeneric sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(CongenericChain sequence)
    {
        return calculator.Calculate(sequence, link);
    }
}
