namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Calculator also storing link.
/// </summary>
public class LinkedFullCalculator
{
    /// <summary>
    /// The link to use for calculation.
    /// </summary>
    private readonly Link link;

    /// <summary>
    /// Actual characteristic calculator.
    /// </summary>
    private readonly IFullCalculator calculator;

    /// <summary>
    /// Initializes a new instance of the <see cref="LinkedFullCalculator"/> class.
    /// </summary>
    /// <param name="type">
    /// Calculator type.
    /// </param>
    /// <param name="link">
    /// The link to use for calculation.
    /// </param>
    public LinkedFullCalculator(FullCharacteristic type, Link link)
    {
        this.link = link;
        calculator = FullCalculatorsFactory.CreateCalculator(type);
    }

    /// <summary>
    /// Calculates characteristic value with given calculator and link.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Calculate(Chain sequence)
    {
        return calculator.Calculate(sequence, link);
    }
}
