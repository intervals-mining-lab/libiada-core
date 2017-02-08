namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class CongenericCalculatorsFactory
    {
        /// <summary>
        /// The list of universal calculators.
        /// </summary>
        private static readonly List<Type> CongenericCalculators = new List<Type>
                                                            {
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
            foreach (var calculator in CongenericCalculators)
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
    }
}
