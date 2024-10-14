namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using System.ComponentModel;

/// <summary>
/// Static factory of different calculators.
/// </summary>
public static class FullCalculatorsFactory
{
    /// <summary>
    /// The create calculator.
    /// </summary>
    /// <param name="type">
    /// The type.
    /// </param>
    /// <returns>
    /// The <see cref="IFullCalculator"/>.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// Thrown if calculator type is unknown.
    /// </exception>
    public static IFullCalculator CreateCalculator(FullCharacteristic type)
    {
        return type switch
        {
            FullCharacteristic.AlphabetCardinality => new AlphabetCardinality(),
            FullCharacteristic.AlphabeticAverageRemoteness => new AlphabeticAverageRemoteness(),
            FullCharacteristic.AlphabeticDepth => new AlphabeticDepth(),
            FullCharacteristic.ArithmeticMean => new ArithmeticMean(),
            FullCharacteristic.ATSkew => new ATSkew(),
            FullCharacteristic.AverageRemoteness => new AverageRemoteness(),
            FullCharacteristic.AverageRemotenessATSkew => new AverageRemotenessATSkew(),
            FullCharacteristic.AverageRemotenessDispersion => new AverageRemotenessDispersion(),
            FullCharacteristic.AverageRemotenessGCRatio => new AverageRemotenessGCRatio(),
            FullCharacteristic.AverageRemotenessGCSkew => new AverageRemotenessGCSkew(),
            FullCharacteristic.AverageRemotenessGCToATRatio => new AverageRemotenessGCToATRatio(),
            FullCharacteristic.AverageRemotenessKurtosis => new AverageRemotenessKurtosis(),
            FullCharacteristic.AverageRemotenessKurtosisCoefficient => new AverageRemotenessKurtosisCoefficient(),
            FullCharacteristic.AverageRemotenessMKSkew => new AverageRemotenessMKSkew(),
            FullCharacteristic.AverageRemotenessRYSkew => new AverageRemotenessRYSkew(),
            FullCharacteristic.AverageRemotenessSkewness => new AverageRemotenessSkewness(),
            FullCharacteristic.AverageRemotenessSkewnessCoefficient => new AverageRemotenessSkewnessCoefficient(),
            FullCharacteristic.AverageRemotenessStandardDeviation => new AverageRemotenessStandardDeviation(),
            FullCharacteristic.AverageRemotenessSWSkew => new AverageRemotenessSWSkew(),
            FullCharacteristic.AverageWordLength => new AverageWordLength(),
            FullCharacteristic.CuttingLength => new CuttingLength(),
            FullCharacteristic.CuttingLengthVocabularyEntropy => new CuttingLengthVocabularyEntropy(),
            FullCharacteristic.Depth => new Depth(),
            FullCharacteristic.DescriptiveInformation => new DescriptiveInformation(),
            FullCharacteristic.ElementsCount => new ElementsCount(),
            FullCharacteristic.EntropyDispersion => new EntropyDispersion(),
            FullCharacteristic.EntropyKurtosis => new EntropyKurtosis(),
            FullCharacteristic.EntropyKurtosisCoefficient => new EntropyKurtosisCoefficient(),
            FullCharacteristic.EntropySkewness => new EntropySkewness(),
            FullCharacteristic.EntropySkewnessCoefficient => new EntropySkewnessCoefficient(),
            FullCharacteristic.EntropyStandardDeviation => new EntropyStandardDeviation(),
            FullCharacteristic.GCRatio => new GCRatio(),
            FullCharacteristic.GCSkew => new GCSkew(),
            FullCharacteristic.GCToATRatio => new GCToATRatio(),
            FullCharacteristic.GeometricMean => new GeometricMean(),
            FullCharacteristic.IdentificationInformation => new IdentificationInformation(),
            FullCharacteristic.InformationAmount => new InformationAmount(),
            FullCharacteristic.IntervalsCount => new IntervalsCount(),
            FullCharacteristic.IntervalsSum => new IntervalsSum(),
            FullCharacteristic.Length => new Length(),
            FullCharacteristic.MKSkew => new MKSkew(),
            FullCharacteristic.Periodicity => new Periodicity(),
            FullCharacteristic.Probability => new Probability(),
            FullCharacteristic.Regularity => new Regularity(),
            FullCharacteristic.RemotenessDispersion => new RemotenessDispersion(),
            FullCharacteristic.RemotenessKurtosis => new RemotenessKurtosis(),
            FullCharacteristic.RemotenessKurtosisCoefficient => new RemotenessKurtosisCoefficient(),
            FullCharacteristic.RemotenessSkewness => new RemotenessSkewness(),
            FullCharacteristic.RemotenessSkewnessCoefficient => new RemotenessSkewnessCoefficient(),
            FullCharacteristic.RemotenessStandardDeviation => new RemotenessStandardDeviation(),
            FullCharacteristic.RYSkew => new RYSkew(),
            FullCharacteristic.SWSkew => new SWSkew(),
            FullCharacteristic.Uniformity => new Uniformity(),
            FullCharacteristic.VariationsCount => new VariationsCount(),
            FullCharacteristic.Volume => new Volume(),
            _ => throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(FullCharacteristic)),
        };
    }
}
