namespace Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

using System.ComponentModel;

/// <summary>
/// Static factory of different calculators.
/// </summary>
public static class BinaryCalculatorsFactory
{
    /// <summary>
    /// The create calculator.
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <returns>
    /// The <see cref="IBinaryCalculator"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown if calculator type is unknown.
    /// </exception>
    public static IBinaryCalculator CreateCalculator(BinaryCharacteristic type)
    {
        return type switch
        {
            BinaryCharacteristic.GeometricMean => new GeometricMean(),
            BinaryCharacteristic.InvolvedPartialDependenceCoefficient => new InvolvedPartialDependenceCoefficient(),
            BinaryCharacteristic.MutualDependenceCoefficient => new MutualDependenceCoefficient(),
            BinaryCharacteristic.NormalizedPartialDependenceCoefficient => new NormalizedPartialDependenceCoefficient(),
            BinaryCharacteristic.PartialDependenceCoefficient => new PartialDependenceCoefficient(),
            BinaryCharacteristic.Redundancy => new Redundancy(),
            _ => throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(BinaryCharacteristic)),
        };
    }
}
