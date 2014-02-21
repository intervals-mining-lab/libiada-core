namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// ����� ������������ ����������.
    /// </summary>
    public class DescriptiveInformation : ICalculator
    {
        /// <summary>
        /// Average arithmetic interval length calculator.
        /// </summary>
        private readonly ICalculator arithmeticMean = new ArithmeticMean();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Descriptive informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            double occupancy = arithmeticMean.Calculate(chain, link);
            return Math.Pow(occupancy, 1 / occupancy);
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Descriptive informations count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 1;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result *= Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.DescriptiveInformation;
        }
    }
}