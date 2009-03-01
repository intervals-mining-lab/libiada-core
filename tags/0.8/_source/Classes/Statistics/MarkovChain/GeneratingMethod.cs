using System;

namespace ChainAnalises.Classes.Statistics.MarkovChain
{
    ///<summary>
    /// ������������ ����� ���������� �����.
    ///</summary>
    [Serializable]
    public enum GeneratingMethod
    {
        ///<summary>
        /// ���������� ���������� ����.
        /// ����������� �� ������� �� ����
        ///</summary>
        StaticUniform,

        ///<summary>
        /// ������������ ���������� ����.
        /// ����������� �� ������� �� ����
        ///</summary>
        StaticNotUniform,

        ///<summary>
        /// ���������� ���������� ����.
        /// ����������� ������� �� ����
        ///</summary>
        DynamicUniform,


        ///<summary>
        /// ������������ ���������� ����.
        /// ����������� ������� �� ����
        ///</summary>
        DynamicNotUniform,

        Random
    } ;
}