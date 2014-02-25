namespace PhantomChains.Classes.Statistics.MarkovChain
{
    using System;

    /// <summary>
    /// ������������ ����� ���������� �����.
    /// </summary>
    [Serializable]
    public enum GeneratingMethod
    {
        /// <summary>
        /// ���������� ���������� ����.
        /// ����������� �� ������� �� ����
        /// </summary>
        StaticUniform,

        /// <summary>
        /// ������������ ���������� ����.
        /// ����������� �� ������� �� ����
        /// </summary>
        StaticNotUniform,

        /// <summary>
        /// ���������� ���������� ����.
        /// ����������� ������� �� ����
        /// </summary>
        DynamicUniform,


        /// <summary>
        /// ������������ ���������� ����.
        /// ����������� ������� �� ����
        /// </summary>
        DynamicNotUniform,

        /// <summary>
        /// The random.
        /// </summary>
        Random
    }
}