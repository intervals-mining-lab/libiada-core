namespace LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators
{
    using System.ComponentModel;

    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class BinaryCalculatorsFactory
    {
        /// <summary>
        /// The create calculator.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IBinaryCalculator"/>.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">
        /// Thrown if calculator type is unknown.
        /// </exception>
        public static IBinaryCalculator CreateCalculator(BinaryCharacteristic type)
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
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(BinaryCharacteristic));
            }
        }
    }
}
