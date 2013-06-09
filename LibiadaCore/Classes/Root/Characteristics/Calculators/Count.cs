namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ���������� ���������.
    ///</summary>
    public class Count : ICharacteristicCalculator
    {
        /// <summary>
        /// ��� ���������� ���� ��� ����������
        /// �������� ���������.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.Intervals.Count - 1;
        }

        /// <summary>
        /// ��� ������ ������������ ���� ��� � �����.
        /// </summary>
        /// <param name="pChain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            int count = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                count += (int)Calculate(pChain.GetUniformChain(i), Link);
            }
            return count;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Count;
        }
    }
}