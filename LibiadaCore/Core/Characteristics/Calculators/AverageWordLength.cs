namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The average length of word (element) in sequence.
    /// </summary>
    public class AverageWordLength : ICalculator
    {
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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not done yet.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Average word length in <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int chainLength = chain.GetLength();
            int sum = 0;

            for (int index = chainLength; --index >= 0;)
            {
                sum = sum + ((ValueString)chain[index]).Value.Length;
            }

            return sum / (double)chainLength;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverageWordLength;
        }
    }
}