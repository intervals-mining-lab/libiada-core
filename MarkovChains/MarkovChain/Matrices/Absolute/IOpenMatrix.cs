namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using System.Collections;

    /// <summary>
    /// ��������� ����������� �������� ������ � ���������� ������ ��������
    /// </summary>
    public interface IOpenMatrix
    {
        /// <summary>
        /// ������ ��������� �������
        /// </summary>
        ArrayList ValueList { get; }

        /// <summary>
        /// ����������� �������
        /// </summary>
        int Rank { get; }

        /// <summary>
        /// �������� �������
        /// </summary>
        double Value { get; }
    }
}