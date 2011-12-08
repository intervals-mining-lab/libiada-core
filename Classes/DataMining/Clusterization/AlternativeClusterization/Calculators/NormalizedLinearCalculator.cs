using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// ����� ��� ���������� �������������� ����������� ���������� 
    /// </summary>
    public class NormalizedLinearCalculator:ICalculator
    {
        /// <summary>
        /// ����� ����������� ������������� ���������� 
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        public void Calculate(GraphManager graph)
        {
            double D = GetDiameter(graph.Connections);
            if(D==0)
            {
                return;
            }
            //������������ �������� ���������� � ��������� (0;1]
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].normalizedDistance = graph.Connections[i].distance / D;  
            } 
        }

        /// <summary>
        /// ����� ��� ���������� �������� �����
        /// (���������� ���� �����)
        /// </summary>
        /// <param name="graph">������ ������ �����</param>
        /// <returns>d - ������������ ����������</returns>
        private double GetDiameter(List<Connection> graph)
        {
            double max = 0;
            for (int i = 0; i < graph.Count; i++)
            {
                if (max < graph[i].distance)
                {
                    max = graph[i].distance;
                }
            }
            return max;
        }
    }
}