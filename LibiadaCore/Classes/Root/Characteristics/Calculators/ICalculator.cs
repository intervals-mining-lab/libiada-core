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
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(CongenericChain chain, LinkUp linkUp);

        ///<summary>
        /// ��������� � ���������� �������� �������������� 
        /// ��� ������ ������������ ������.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(Chain chain, LinkUp linkUp);

        ///<summary>
        /// ���������� ��� �������������� ����������� �������������
        ///</summary>
        ///<returns>��� � ���� ������, �������� Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}