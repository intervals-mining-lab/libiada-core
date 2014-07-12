namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Дисперсия средней удаленности.
    /// </summary>
    public class AverageRemotenessDispersion : ICalculator
    {

        private readonly ICalculator averageRemoteness = new AverageRemoteness();
        private readonly ICalculator elementsCount = new ElementsCount();
        private readonly ICalculator length = new Length();

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
        /// 
        public double Calculate(CongenericChain chain, Link link)
        {
            throw new InvalidOperationException("Дисперсия средней удаленности вычисляется только для полных цепей.");
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
        /// Average remoteness <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double result = 0;
            double g = this.averageRemoteness.Calculate(chain, link);
            double n = this.length.Calculate(chain, link);
            
            
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = this.elementsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gj = averageRemoteness.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                result += nj / n * (gj - g) * (gj - g);
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
            return CharacteristicsEnum.AverageRemotenessDispersion;
        }
    }
}