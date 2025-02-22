namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System.ComponentModel;

/// <summary>
/// Static factory of different calculators.
/// </summary>
public static class CongenericCalculatorsFactory
{
    /// <summary>
    /// Creates calculator for given congeneric characteristic.
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <returns>
    /// The <see cref="ICongenericCalculator"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown if calculator type is unknown.
    /// </exception>
    public static ICongenericCalculator CreateCalculator(CongenericCharacteristic type)
    {
        return type switch
        {
            CongenericCharacteristic.ArithmeticMean => new ArithmeticMean(),
            CongenericCharacteristic.AverageRemoteness => new AverageRemoteness(),
            CongenericCharacteristic.CuttingLength => new CuttingLength(),
            CongenericCharacteristic.CuttingLengthVocabularyEntropy => new CuttingLengthVocabularyEntropy(),
            CongenericCharacteristic.Depth => new Depth(),
            CongenericCharacteristic.ElementsCount => new ElementsCount(),
            CongenericCharacteristic.GeometricMean => new GeometricMean(),
            CongenericCharacteristic.IdentifyingInformation => new IdentifyingInformation(),
            CongenericCharacteristic.IntervalsCount => new IntervalsCount(),
            CongenericCharacteristic.IntervalsSum => new IntervalsSum(),
            CongenericCharacteristic.Length => new Length(),
            CongenericCharacteristic.Periodicity => new Periodicity(),
            CongenericCharacteristic.Probability => new Probability(),
            CongenericCharacteristic.Uniformity => new Uniformity(),
            CongenericCharacteristic.VariationsCount => new VariationsCount(),
            CongenericCharacteristic.Volume => new Volume(),
            CongenericCharacteristic.RemotenessVariance => new RemotenessVariance(),
            CongenericCharacteristic.RemotenessKurtosis => new RemotenessKurtosis(),
            CongenericCharacteristic.RemotenessKurtosisCoefficient => new RemotenessKurtosisCoefficient(),
            CongenericCharacteristic.RemotenessSkewness => new RemotenessSkewness(),
            CongenericCharacteristic.RemotenessSkewnessCoefficient => new RemotenessSkewnessCoefficient(),
            CongenericCharacteristic.RemotenessStandardDeviation => new RemotenessStandardDeviation(),
            CongenericCharacteristic.InformationAmount => new InformationAmount(),
            _ => throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(CongenericCharacteristic)),
        };
    }
}
