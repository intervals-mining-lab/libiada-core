namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// ����������� �����-�������� ��� ���� �������������
    /// </summary>
    public static class CommonCalculator
    {
        /// <summary>
        /// ��������� �� ������� ��������� ����������, ������������� ��������� ����������,
        ///  ��������� ��������� �����, ������������� ��������� ��������� ����� � ������-����������
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����.
        /// </param>
        /// <param name="normalizedDistanceWeight">
        /// The normalized distance weight.
        /// </param>
        /// <param name="distanceWeight">
        /// The distance weight.
        /// </param>
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanceWeight, double distanceWeight)
        {
            ICalculator calc = new LinearCalculator();
            calc.Calculate(graph);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(graph);
            calc = new TauStarCalculator();
            calc.Calculate(graph);
            calc = new TauCalculator();
            calc.Calculate(graph);
            var lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(graph, normalizedDistanceWeight, distanceWeight);
        }
    }
}
