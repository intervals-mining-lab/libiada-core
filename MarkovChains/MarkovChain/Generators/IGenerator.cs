namespace MarkovChains.MarkovChain.Generators
{
    /// <summary>
    /// ��������� ��� ����������� ������������� ��������
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// �������������� ��������� �����.
        /// </summary>
        void Reset();

        /// <summary>
        /// �������� ��������� �������� �������������� ��������.
        /// </summary>
        /// <returns>
        /// [0..1] ��������
        /// </returns>
        double Next();
    }
}