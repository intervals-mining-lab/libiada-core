namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ���������� ���������.
    ///</summary>
    public class Count : ICalculator
    {
        /// <summary>
        /// ���������� �������� �������, 
        /// ����� ������ ���������� ���������.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            return chain.Intervals.Count - 1;
        }

        /// <summary>
        /// ���������� �������� �������.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            int count = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                count += (int)Calculate(chain.CongenericChain(i), linkUp);
            }
            return count;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Count;
        }
    }
}