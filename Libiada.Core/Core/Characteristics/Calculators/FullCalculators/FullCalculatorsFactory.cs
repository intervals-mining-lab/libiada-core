namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
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
            switch (type)
            {
                case FullCharacteristic.AlphabetCardinality:
                    return new AlphabetCardinality();
                case FullCharacteristic.AlphabeticAverageRemoteness:
                    return new AlphabeticAverageRemoteness();
                case FullCharacteristic.AlphabeticDepth:
                    return new AlphabeticDepth();
                case FullCharacteristic.ArithmeticMean:
                    return new ArithmeticMean();
                case FullCharacteristic.ATSkew:
                    return new ATSkew();
                case FullCharacteristic.AverageRemoteness:
                    return new AverageRemoteness();
                case FullCharacteristic.AverageRemotenessATSkew:
                    return new AverageRemotenessATSkew();
                case FullCharacteristic.AverageRemotenessDispersion:
                    return new AverageRemotenessDispersion();
                case FullCharacteristic.AverageRemotenessGCRatio:
                    return new AverageRemotenessGCRatio();
                case FullCharacteristic.AverageRemotenessGCSkew:
                    return new AverageRemotenessGCSkew();
                case FullCharacteristic.AverageRemotenessGCToATRatio:
                    return new AverageRemotenessGCToATRatio();
                case FullCharacteristic.AverageRemotenessKurtosis:
                    return new AverageRemotenessKurtosis();
                case FullCharacteristic.AverageRemotenessKurtosisCoefficient:
                    return new AverageRemotenessKurtosisCoefficient();
                case FullCharacteristic.AverageRemotenessMKSkew:
                    return new AverageRemotenessMKSkew();
                case FullCharacteristic.AverageRemotenessRYSkew:
                    return new AverageRemotenessRYSkew();
                case FullCharacteristic.AverageRemotenessSkewness:
                    return new AverageRemotenessSkewness();
                case FullCharacteristic.AverageRemotenessSkewnessCoefficient:
                    return new AverageRemotenessSkewnessCoefficient();
                case FullCharacteristic.AverageRemotenessStandardDeviation:
                    return new AverageRemotenessStandardDeviation();
                case FullCharacteristic.AverageRemotenessSWSkew:
                    return new AverageRemotenessSWSkew();
                case FullCharacteristic.AverageWordLength:
                    return new AverageWordLength();
                case FullCharacteristic.CuttingLength:
                    return new CuttingLength();
                case FullCharacteristic.CuttingLengthVocabularyEntropy:
                    return new CuttingLengthVocabularyEntropy();
                case FullCharacteristic.Depth:
                    return new Depth();
                case FullCharacteristic.DescriptiveInformation:
                    return new DescriptiveInformation();
                case FullCharacteristic.ElementsCount:
                    return new ElementsCount();
                case FullCharacteristic.EntropyDispersion:
                    return new EntropyDispersion();
                case FullCharacteristic.EntropyKurtosis:
                    return new EntropyKurtosis();
                case FullCharacteristic.EntropyKurtosisCoefficient:
                    return new EntropyKurtosisCoefficient();
                case FullCharacteristic.EntropySkewness:
                    return new EntropySkewness();
                case FullCharacteristic.EntropySkewnessCoefficient:
                    return new EntropySkewnessCoefficient();
                case FullCharacteristic.EntropyStandardDeviation:
                    return new EntropyStandardDeviation();
                case FullCharacteristic.GCRatio:
                    return new GCRatio();
                case FullCharacteristic.GCSkew:
                    return new GCSkew();
                case FullCharacteristic.GCToATRatio:
                    return new GCToATRatio();
                case FullCharacteristic.GeometricMean:
                    return new GeometricMean();
                case FullCharacteristic.IdentificationInformation:
                    return new IdentificationInformation();
                case FullCharacteristic.InformationAmount:
                    return new InformationAmount();
                case FullCharacteristic.IntervalsCount:
                    return new IntervalsCount();
                case FullCharacteristic.IntervalsSum:
                    return new IntervalsSum();
                case FullCharacteristic.Length:
                    return new Length();
                case FullCharacteristic.MKSkew:
                    return new MKSkew();
                case FullCharacteristic.Periodicity:
                    return new Periodicity();
                case FullCharacteristic.Probability:
                    return new Probability();
                case FullCharacteristic.Regularity:
                    return new Regularity();
                case FullCharacteristic.RemotenessDispersion:
                    return new RemotenessDispersion();
                case FullCharacteristic.RemotenessKurtosis:
                    return new RemotenessKurtosis();
                case FullCharacteristic.RemotenessKurtosisCoefficient:
                    return new RemotenessKurtosisCoefficient();
                case FullCharacteristic.RemotenessSkewness:
                    return new RemotenessSkewness();
                case FullCharacteristic.RemotenessSkewnessCoefficient:
                    return new RemotenessSkewnessCoefficient();
                case FullCharacteristic.RemotenessStandardDeviation:
                    return new RemotenessStandardDeviation();
                case FullCharacteristic.RYSkew:
                    return new RYSkew();
                case FullCharacteristic.SWSkew:
                    return new SWSkew();
                case FullCharacteristic.Uniformity:
                    return new Uniformity();
                case FullCharacteristic.VariationsCount:
                    return new VariationsCount();
                case FullCharacteristic.Volume:
                    return new Volume();
                default:
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(FullCharacteristic));
            }
        }
    }
}
