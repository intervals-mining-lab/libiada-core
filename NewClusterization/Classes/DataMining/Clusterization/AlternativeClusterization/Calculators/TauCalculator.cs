using System.Collections.Generic;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// ����� ��� ���������� ������������� ��������� ��������� �����
    /// � ����������� ������ ���� �����
    /// </summary>
    public class TauCalculator:ICalculator
    {

        /// <summary>
        /// ����� ����������� ������������� ��������� ��������� ����� 
        /// � ����������� ������ ���� �����
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        public void Calculate(GraphManager graph)
        {
            double tauMax = GetTauStarMax(graph.Connections);
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].tau = graph.Connections[i].tauStar / tauMax;
            }
        }

        /// <summary>
        /// ����� ���������� ������������ ��������� ����� � �����
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        /// <returns>Tmax - ������������ ���������</returns>
        private  double  GetTauStarMax (List<Connection> graph)
        {
            double result=0;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].tauStar>result)
                {
                    result = graph[i].tauStar;
                }
            }
            return result;
        }
    }
}