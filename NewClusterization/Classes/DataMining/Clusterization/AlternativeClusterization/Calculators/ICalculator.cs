namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// ��������� ������������,
    /// ����������� ��� �������� �������������
    /// </summary>
    public interface ICalculator
    {
        ///<summary>
        /// ����� ��������� �����-���� ���������� ��� �����.
        ///</summary>
        ///<param name="graph">����</param>
        void Calculate(GraphManager graph);

    }
}