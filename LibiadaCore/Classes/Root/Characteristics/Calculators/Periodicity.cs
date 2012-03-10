namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// �������������.
    /// ����� ����� ������ ��� ���������� ����.
    ///</summary>
    public class Periodicity : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG)/
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG) /
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}