namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Количество элементов.
    /// </summary>
    public class Count : ICalculator
    {
        /// <summary>
        /// Количество непустых позиций, 
        /// иначе говоря количество элементов.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.Intervals.Count - 1;
        }

        /// <summary>
        /// Количество непустых позиций.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            int count = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                count += (int)Calculate(chain.CongenericChain(i), link);
            }
            return count;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Count;
        }
    }
}