namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    using System;

    /// <summary>
    /// ����� ����������� ������-���������� ��� ���� ����� �����
    /// </summary>
    public class LambdaCalculator
    {
        /// <summary>
        /// ����� ���������� ICalculator, 
        /// ����������� ������-����������
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
        public void Calculate(GraphManager graph, double normalizedDistanceWeight, double distanceWeight)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].Lambda = Math.Pow(graph.Connections[i].Tau, normalizedDistanceWeight) *
                                         Math.Pow(graph.Connections[i].Distance, distanceWeight);
            }
        }
    }
}