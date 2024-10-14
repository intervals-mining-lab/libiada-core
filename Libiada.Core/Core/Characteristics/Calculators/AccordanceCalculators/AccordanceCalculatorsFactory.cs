namespace Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

using System.ComponentModel;

/// <summary>
/// Static factory of different calculators.
/// </summary>
public static class AccordanceCalculatorsFactory
{
    /// <summary>
    /// The create calculator.
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <returns>
    /// The <see cref="IAccordanceCalculator"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown if calculator type is unknown.
    /// </exception>
    public static IAccordanceCalculator CreateCalculator(AccordanceCharacteristic type)
    {
        return type switch
        {
            AccordanceCharacteristic.MutualComplianceDegree => new MutualComplianceDegree(),
            AccordanceCharacteristic.PartialComplianceDegree => new PartialComplianceDegree(),
            _ => throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(AccordanceCharacteristic)),
        };
    }
}
