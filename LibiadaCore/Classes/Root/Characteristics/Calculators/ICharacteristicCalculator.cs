namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ��������� ������������
    ///</summary>
    public interface ICharacteristicCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        double Calculate(UniformChain pChain, LinkUp Link);

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        double Calculate(Chain pChain, LinkUp Link);

        ///<summary>
        /// ���������� ��� �������������� ����������� �������������
        ///</summary>
        ///<returns>��� � ���� ������, �������� Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}