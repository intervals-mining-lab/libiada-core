namespace LibiadaCore.Core.Characteristics
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// —татическа€ фабрика различных калькул€торов.
    /// </summary>
    public static class CalculatorsFactory
    {
        /// <summary>
        /// —писок калькул€торов характеристик.
        /// </summary>
        private static readonly List<Type> Calculators = new List<Type>
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
                                                                typeof(AlphabetCardinality),
                                                                typeof(AlphabeticAverageRemoteness),
                                                                typeof(AlphabeticDepth),
                                                                typeof(AverageWordLength),
                                                                typeof(AverageRemotenessSkewness),
                                                                typeof(AverageRemotenessDispersion),
                                                                typeof(AverageRemotenessStandardDeviation),
                                                                typeof(NormalizedRemotenessStandardDeviation)
                                                            };

        /// <summary>
        /// Create full calcualtor method.
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
            foreach (var calculator in Calculators)
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
        /// Create full calcualtor method.
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
        /// Create congeneric calcualtor method.
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
            foreach (var calculator in Calculators)
            {
                if (type == calculator.Name)
                {
                    return (ICongenericCalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create congeneric calcualtor method.
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
        ///  Create calcualtor method.
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
            foreach (var calculator in Calculators)
            {
                if (type == calculator.Name)
                {
                    return (ICalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create calcualtor method.
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
    }
}