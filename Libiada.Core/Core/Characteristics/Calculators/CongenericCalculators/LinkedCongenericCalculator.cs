namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Calculator that also stores the link.
/// </summary>
public class LinkedCongenericCalculator
{
    /// <summary>
    /// The link to use for calculation.
    /// </summary>
    private readonly Link link;

    /// <summary>
    /// Actual characteristic calculator.
    /// </summary>
    private readonly ICongenericCalculator calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="LinkedFullCalculator"/> class.
    /// </summary>
    /// <param name="type">
    /// Calculator type.
    /// </param>
    /// <param name="link">
    /// The link to use for calculation.
    /// </param>
    public LinkedCongenericCalculator(CongenericCharacteristic type, Link link)
    {
        this.link = link;
        calculator = CongenericCalculatorsFactory.CreateCalculator(type);
    }

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
