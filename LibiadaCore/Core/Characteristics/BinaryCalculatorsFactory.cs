namespace LibiadaCore.Core.Characteristics
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.Characteristics.BinaryCalculators;
    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// The binary calculators factory.
    /// </summary>
    public static class BinaryCalculatorsFactory
    {
        /// <summary>
        /// The calculators.
        /// </summary>
        private static readonly List<Type> Calculators = new List<Type>
                                                            {
                                                                typeof(InvolvedPartialDependenceCoefficient),
                                                                typeof(MutualDependenceCoefficient),
                                                                typeof(NormalizedPartialDependenceCoefficient),
                                                                typeof(PartialDependenceCoefficient),
                                                                typeof(Redundancy),
                                                                typeof(BinaryGeometricMean)
                                                            };

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
        public static IBinaryCalculator CreateCalculator(string type)
        {
            foreach (var calculator in Calculators)
            {
                if (type == calculator.Name)
                {
                    return (IBinaryCalculator)Activator.CreateInstance(calculator);
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
        public static IBinaryCalculator CreateCalculator(Type type)
        {
            return CreateCalculator(type.Name);
        }
    }
}