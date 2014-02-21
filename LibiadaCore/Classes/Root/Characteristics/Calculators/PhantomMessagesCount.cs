namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// Число возможных цепочек которые можно сгенерировать 
    /// из данной цепочки, содержащей фантомные сообщения.
    /// </summary>
    public class PhantomMessagesCount : ICalculator
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
        /// Phantom chain count as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            int count = 1;
            for (int i = 0; i < chain.Length; i++)
            {
                var j = chain[i] as ValuePhantom;
                if (j != null)
                {
                    count *= ((ValuePhantom)chain[i]).Cardinality;
                }
            }

            return count;
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
        /// Phantom chain count as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int count = 1;
            for (int i = 0; i < chain.Length; i++)
            {
                var j = chain[i] as ValuePhantom;
                if (j != null)
                {
                    count *= ((ValuePhantom)chain[i]).Cardinality;
                }
            }

            return count;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.PhantomMessageCount;
        }
    }
}
