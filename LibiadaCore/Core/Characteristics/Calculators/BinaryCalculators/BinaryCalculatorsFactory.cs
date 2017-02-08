using System;
using System.Collections.Generic;

namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class BinaryCalculatorsFactory
    {
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
            typeof(GeometricMean)
        };

        /// <summary>
        ///  Create binary calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IBinaryCalculator"/>.
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
                    return (IBinaryCalculator) Activator.CreateInstance(calculator);
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
        /// The <see cref="IBinaryCalculator"/>.
        /// </returns>
        public static IBinaryCalculator CreateBinaryCalculator(Type type)
        {
            return CreateBinaryCalculator(type.Name);
        }
    }
}
