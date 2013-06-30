namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    ///<summary>
    /// ����������� �����-�������� ��� ���� �������������
    ///</summary>
    public static class CommonCalculator
    {
        /// <summary>
        /// ��������� �� ������� ��������� ����������, ������������� ��������� ����������,
        ///  ��������� ��������� �����, ������������� ��������� ��������� ����� � ������-����������
        /// </summary>
        /// <param name="graph"> ������ ������ �����</param>
        /// <param name="normalizedDistanseWeight"> </param>
        /// <param name="distanseWeight"> </param>
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanseWeight, double distanseWeight)
        {
            ICalculator calc = new LinearCalculator();
            calc.Calculate(graph);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(graph);
            calc = new TauStarCalculator();
            calc.Calculate(graph);
            calc = new TauCalculator();
            calc.Calculate(graph);
            LambdaCalculator lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(graph,normalizedDistanseWeight, distanseWeight);
        }
    }
}