namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// ��������� ������������,
    /// ����������� ��� �������� �������������
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// ����� ��������� �����-���� ���������� ��� �����.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        void Calculate(GraphManager graph);

    }
}