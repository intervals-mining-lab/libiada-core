namespace MarkovChains.MarkovChain
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
        StaticCongeneric,

        /// <summary>
        /// ������������ ���������� ����.
        /// ����������� �� ������� �� ����
        /// </summary>
        StaticNotCongeneric,

        /// <summary>
        /// ���������� ���������� ����.
        /// ����������� ������� �� ����
        /// </summary>
        DynamicCongeneric,

        /// <summary>
        /// ������������ ���������� ����.
        /// ����������� ������� �� ����
        /// </summary>
        DynamicNotCongeneric,

        /// <summary>
        /// The random.
        /// </summary>
        Random
    }
}