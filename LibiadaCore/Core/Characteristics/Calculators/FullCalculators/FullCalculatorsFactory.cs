using System;
using System.Collections.Generic;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class FullCalculatorsFactory
    {
        /// <summary>
        /// The full calculators.
        /// </summary>
        private static readonly List<Type> FullCalculators = new List<Type>
                                                            {
                                                                typeof(ATSkew),
                                                                typeof(GCRatio),
                                                                typeof(GCSkew),
                                                                typeof(GCToATRatio),
                                                                typeof(MKSkew),
                                                                typeof(RYSkew),
                                                                typeof(SWSkew),
                                                                typeof(AlphabetCardinality),
                                                                typeof(AlphabeticAverageRemoteness),
                                                                typeof(AlphabeticDepth),
                                                                typeof(AverageWordLength),
                                                                typeof(AverageRemotenessATSkew),
                                                                typeof(AverageRemotenessGCRatio),
                                                                typeof(AverageRemotenessGCSkew),
                                                                typeof(AverageRemotenessGCToATRatio),
                                                                typeof(AverageRemotenessMKSkew),
                                                                typeof(AverageRemotenessRYSkew),
                                                                typeof(AverageRemotenessSWSkew),
                                                                typeof(AverageRemotenessDispersion),
                                                                typeof(AverageRemotenessStandardDeviation),
                                                                typeof(AverageRemotenessSkewness),
                                                                typeof(AverageRemotenessSkewnessCoefficient),
                                                                typeof(AverageRemotenessKurtosis),
                                                                typeof(AverageRemotenessKurtosisCoefficient),
                                                                typeof(RemotenessDispersion),
                                                                typeof(RemotenessKurtosis),
                                                                typeof(RemotenessKurtosisCoefficient),
                                                                typeof(RemotenessSkewness),
                                                                typeof(RemotenessSkewnessCoefficient),
                                                                typeof(RemotenessStandardDeviation),
                                                                typeof(EntropyDispersion),
                                                                typeof(EntropyStandardDeviation),
                                                                typeof(EntropySkewness),
                                                                typeof(EntropySkewnessCoefficient),
                                                                typeof(EntropyKurtosis),
                                                                typeof(EntropyKurtosisCoefficient),
                                                                typeof(ArithmeticMean),
                                                                typeof(AverageRemoteness),
                                                                typeof(CuttingLength),
                                                                typeof(CuttingLengthVocabularyEntropy),
                                                                typeof(Depth),
                                                                typeof(DescriptiveInformation),
                                                                typeof(ElementsCount),
                                                                typeof(GeometricMean),
                                                                typeof(IdentificationInformation),
                                                                typeof(IntervalsCount),
                                                                typeof(IntervalsSum),
                                                                typeof(Length),
                                                                typeof(Periodicity),
                                                                typeof(VariationsCount),
                                                                typeof(Probability),
                                                                typeof(Regularity),
                                                                typeof(Volume),
                                                                typeof(Uniformity)
                                                            };

        /// <summary>
        /// Create full calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IFullCalculator"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if calculator is not found by name.
        /// </exception>
        public static IFullCalculator CreateFullCalculator(string type)
        {
            foreach (var calculator in FullCalculators)
            {
                if (type == calculator.Name)
                {
                    return (IFullCalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create full calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IFullCalculator"/>.
        /// </returns>
        public static IFullCalculator CreateFullCalculator(Type type)
        {
            return CreateFullCalculator(type.Name);
        }
    }
}
