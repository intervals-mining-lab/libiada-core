namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
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
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanseWeight, double distanseWeight)
        {
            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(graph);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(graph);
            Calc = new TauStarCalculator();
            Calc.Calculate(graph);
            Calc = new TauCalculator();
            Calc.Calculate(graph);
            LambdaCalculator lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(graph,normalizedDistanseWeight, distanseWeight);
        }
    }
}