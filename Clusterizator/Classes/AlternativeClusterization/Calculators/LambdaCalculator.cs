using System;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    ///<summary>
    /// ����� ����������� ������-���������� ��� ���� ����� �����
    ///</summary>
    public class LambdaCalculator
    {
        /// <summary>
        /// ����� ���������� ICalculator, 
        /// ����������� ������-����������
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        /// <param name="normalizedDistanceWeight"> </param>
        /// <param name="distanceWeight"> </param>
        public void Calculate(GraphManager graph, double normalizedDistanceWeight, double distanceWeight)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].lambda = Math.Pow(graph.Connections[i].Tau, normalizedDistanceWeight)*
                                         Math.Pow(graph.Connections[i].Distance, distanceWeight);
            }
        }
    }
}