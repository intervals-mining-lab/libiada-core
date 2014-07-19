namespace MarkovChains.MarkovChain
{
    /// <summary>
    /// ����� ������������� ����
    /// </summary>
    public enum TeachingMethod
    {
        /// <summary>
        /// ��������� �������������
        /// </summary>
        None,

        /// <summary>
        /// ��������� � ������ (��������� �������������� ������)
        /// </summary>
        Cycle,

        /// <summary>
        /// ��������� � ������ (��������� ���������� � ����� ����)
        /// </summary>
        CycleBuilding
    }
}