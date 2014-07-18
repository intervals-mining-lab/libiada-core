using System.Collections.Generic;

namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// ����� ��� ���������� ������������� ��������� ��������� �����
    /// � ����������� ������ ���� �����
    /// </summary>
    public class TauCalculator : ICalculator
    {
        /// <summary>
        /// ����� ����������� ������������� ��������� ��������� ����� 
        /// � ����������� ������ ���� �����
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            double tauMax = GetTauStarMax(graph.Connections);
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].Tau = graph.Connections[i].TauStar / tauMax;
            }
        }

        /// <summary>
        /// ����� ���������� ������������ ��������� ����� � �����
        /// </summary>
        /// <param name="graph">
        /// ������ ������ �����.
        /// </param>
        /// <returns>
        /// Tmax - ������������ ���������
        /// </returns>
        private double GetTauStarMax(List<Connection> graph)
        {
            double result = 0;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].TauStar > result)
                {
                    result = graph[i].TauStar;
                }
            }
            return result;
        }
    }
}