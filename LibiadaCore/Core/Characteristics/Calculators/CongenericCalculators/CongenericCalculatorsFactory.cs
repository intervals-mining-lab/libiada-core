namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    using System.ComponentModel;

    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class CongenericCalculatorsFactory
    {
        /// <summary>
        /// The create calculator.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ICongenericCalculator"/>.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">
        /// Thrown if calculator type is unknown.
        /// </exception>
        public static ICongenericCalculator CreateCalculator(CongenericCharacteristic type)
        {
            switch (type)
            {
                case CongenericCharacteristic.ArithmeticMean:
                    return new ArithmeticMean();
                case CongenericCharacteristic.AverageRemoteness:
                    return new AverageRemoteness();
                case CongenericCharacteristic.CuttingLength:
                    return new CuttingLength();
                case CongenericCharacteristic.CuttingLengthVocabularyEntropy:
                    return new CuttingLengthVocabularyEntropy();
                case CongenericCharacteristic.Depth:
                    return new Depth();
                case CongenericCharacteristic.DescriptiveInformation:
                    return new DescriptiveInformation();
                case CongenericCharacteristic.ElementsCount:
                    return new ElementsCount();
                case CongenericCharacteristic.GeometricMean:
                    return new GeometricMean();
                case CongenericCharacteristic.IdentificationInformation:
                    return new IdentificationInformation();
                case CongenericCharacteristic.IntervalsCount:
                    return new IntervalsCount();
                case CongenericCharacteristic.IntervalsSum:
                    return new IntervalsSum();
                case CongenericCharacteristic.Length:
                    return new Length();
                case CongenericCharacteristic.Periodicity:
                    return new Periodicity();
                case CongenericCharacteristic.Probability:
                    return new Probability();
                case CongenericCharacteristic.Regularity:
                    return new Regularity();
                case CongenericCharacteristic.Uniformity:
                    return new Uniformity();
                case CongenericCharacteristic.VariationsCount:
                    return new VariationsCount();
                case CongenericCharacteristic.Volume:
                    return new Volume();
                default:
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(CongenericCharacteristic));
            }
        }
    }
}
