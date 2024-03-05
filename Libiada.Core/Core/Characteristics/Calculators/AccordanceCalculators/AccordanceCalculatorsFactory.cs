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
        switch (type)
        {
            case AccordanceCharacteristic.MutualComplianceDegree:
                return new MutualComplianceDegree();
            case AccordanceCharacteristic.PartialComplianceDegree:
                return new PartialComplianceDegree();
            default:
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(AccordanceCharacteristic));
        }
    }
}
