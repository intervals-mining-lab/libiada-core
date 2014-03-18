namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// The average remoteness with logarithm base equals cardinality of alphabet.
    /// </summary>
    public class AlphabeticAverageRemoteness : ICalculator
    {
        /// <summary>
        /// The geometric mean.
        /// </summary>
        private readonly GeometricMean geometricMean = new GeometricMean();

        /// <summary>
        /// Characteristic cannot be calculated for congeneric chains.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Always throws the exception because this operation is not applicable to congeneric chains.
        /// </exception>
        public double Calculate(CongenericChain chain, Link link)
        {
            throw new InvalidOperationException("Алфавитная удалённость вычисляется только для полных цепей.");
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
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int alphabetCardinality = chain.Alphabet.Cardinality;
            return Math.Log(this.geometricMean.Calculate(chain, link), alphabetCardinality);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabeticAverageRemoteness;
        }
    }
}