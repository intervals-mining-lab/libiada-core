namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using System;
    using System.Collections.Generic;

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
        /// The <see cref="IBinaryCalculator"/>.
        /// </returns>
        public static IBinaryCalculator CreateBinaryCalculator(Type type)
        {
            return CreateBinaryCalculator(type.Name);
        }

        public static IBinaryCalculator CreatCalculator(BinaryCharacteristic type)
        {
            switch (type)
            {
                case BinaryCharacteristic.GeometricMean:
                    return new GeometricMean();
                case BinaryCharacteristic.InvolvedPartialDependenceCoefficient:
                    return new InvolvedPartialDependenceCoefficient();
                case BinaryCharacteristic.MutualDependenceCoefficient:
                    return new MutualDependenceCoefficient();
                case BinaryCharacteristic.NormalizedPartialDependenceCoefficient:
                    return new NormalizedPartialDependenceCoefficient();
                case BinaryCharacteristic.PartialDependenceCoefficient:
                    return new PartialDependenceCoefficient();
                case BinaryCharacteristic.Redundancy:
                    return new Redundancy();
                default:
                    throw new ArgumentException("Unknown binary characteristic type");
            }
        }
    }
}
