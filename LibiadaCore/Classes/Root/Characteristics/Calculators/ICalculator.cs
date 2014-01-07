namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ��������� ������������
    ///</summary>
    public interface ICalculator
    {
        ///<summary>
        /// ��������� � ���������� �������� �������������� 
        /// ��� ���������� ������.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        double Calculate(CongenericChain chain, Link link);

        ///<summary>
        /// ��������� � ���������� �������� �������������� 
        /// ��� ������ ������������ ������.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        double Calculate(Chain chain, Link link);

        ///<summary>
        /// ���������� ��� �������������� ����������� �������������
        ///</summary>
        ///<returns>��� � ���� ������, �������� Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}