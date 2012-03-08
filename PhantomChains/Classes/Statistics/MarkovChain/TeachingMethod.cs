using System;

namespace PhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ����� ������������� ����
    ///</summary>
    [Serializable]
    public enum TeachingMethod
    {
        ///<summary>
        /// ��������� �������������
        ///</summary>
        None,
        ///<summary>
        /// ��������� � ������ (��������� �������������� ������)
        ///</summary>
        Cycle,
        ///<summary>
        /// ��������� � ������ (��������� ���������� � ����� ����)
        ///</summary>
        CycleBuilding
    } ;
}