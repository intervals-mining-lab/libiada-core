namespace LibiadaCore.Core.Characteristics
{
    using System;
    using System.Collections.Generic;
    using Calculators;

    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class CalculatorsFactory
    {
        /// <summary>
        /// The list of universal calculators.
        /// </summary>
        private static readonly List<Type> UniversalCalculators = new List<Type>
                                                            {
                                                                typeof(ArithmeticMean),
                                                                typeof(AverageRemoteness),
                                                                typeof(CutLength),
                                                                typeof(CutLengthVocabularyEntropy),
                                                                typeof(Depth),
                                                                typeof(DescriptiveInformation),
                                                                typeof(ElementsCount),
                                                                typeof(GeometricMean),
                                                                typeof(IdentificationInformation),
                                                                typeof(IntervalsCount),
                                                                typeof(IntervalsSum),
                                                                typeof(Length),
                                                                typeof(NormalizedAverageRemoteness),
                                                                typeof(NormalizedDepth),
                                                                typeof(Periodicity),
                                                                typeof(PhantomMessagesCount),
                                                                typeof(Probability),
                                                                typeof(Regularity),
                                                                typeof(Volume)
                                                            };

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
                                                                typeof(RemotenessStandardDeviation)
                                                                
                                                            };

        /// <summary>
        /// The binary calculators.
        /// </summary>
        private static readonly List<Type> BinaryCalculators = new List<Type>
                                                            {
                                                                typeof(InvolvedPartialDependenceCoefficient),
                                                                typeof(MutualDependenceCoefficient),
                                                                typeof(NormalizedPartialDependenceCoefficient),
                                                                typeof(PartialDependenceCoefficient),
                                                                typeof(Redundancy),
                                                                typeof(GeometricMean),
                                                                typeof(ComplianceDegree)
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
            foreach (var calculator in UniversalCalculators)
            {
                if (type == calculator.Name)
                {
                    return (IFullCalculator)Activator.CreateInstance(calculator);
                }
            }

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

        /// <summary>
        /// Create congeneric calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICongenericCalculator"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if calculator is not found by name.
        /// </exception>
        public static ICongenericCalculator CreateCongenericCalculator(string type)
        {
            foreach (var calculator in UniversalCalculators)
            {
                if (type == calculator.Name)
                {
                    return (ICongenericCalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create congeneric calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICongenericCalculator"/>.
        /// </returns>
        public static ICongenericCalculator CreateCongenericCalculator(Type type)
        {
            return CreateCongenericCalculator(type.Name);
        }

        /// <summary>
        ///  Create calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICalculator"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if calculator is not found by name.
        /// </exception>
        public static ICalculator CreateCalculator(string type)
        {
            foreach (var calculator in UniversalCalculators)
            {
                if (type == calculator.Name)
                {
                    return (ICalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICalculator"/>.
        /// </returns>
        public static ICalculator CreateCalculator(Type type)
        {
            return CreateCalculator(type.Name);
        }

        /// <summary>
        ///  Create binary calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICalculator"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if calculator is not found by name.
        /// </exception>
        public static IBinaryCalculator CreateBinaryCalculator(string type)
        {
            foreach (var calculator in BinaryCalculators)
            {
                if (type == calculator.Name)
                {
                    return (IBinaryCalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create binary calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICalculator"/>.
        /// </returns>
        public static IBinaryCalculator CreateBinaryCalculator(Type type)
        {
            return CreateBinaryCalculator(type.Name);
        }
    }
}
