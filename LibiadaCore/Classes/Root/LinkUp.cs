namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// �������� ����������
    ///</summary>
    public enum LinkUp
    {
        ///<summary>
        /// �������� � ������
        /// �� ����������� �������� 
        /// �� ���������� �������� �� ����� �������
        ///</summary>
        Start = 1,
        ///<summary>
        /// �������� � �����
        /// �� ����������� �� ������ �� ������� �������� �������
        ///</summary>
        End = 2,
        ///<summary>
        /// �������� � ������ � � �����
        /// ����������� ��� ���������
        ///</summary>
        Both = 3,
        ///<summary>
        /// ����������� ��������
        /// �������� �� ������ �� ������� �������� 
        /// � �� ���������� �������� �� �����
        /// ����������� � ����
        ///</summary>
        Cycle = 4,
        ///<summary>
        /// ��� ��������
        /// �� ����������� �� �������� �� ������ �� ������� ��������
        /// �� �� ���������� �������� �� �����
        ///</summary>
        None = 5
    }
}