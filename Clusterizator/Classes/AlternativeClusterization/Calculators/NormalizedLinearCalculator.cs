using System;
using System.Collections.Generic;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
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
            if(Math.Abs(D - 0) < 0.00001)
            {
                return;
            }
            //������������ �������� ���������� � ��������� (0;1]
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].NormalizedDistance = graph.Connections[i].Distance / D;  
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
                if (max < graph[i].Distance)
                {
                    max = graph[i].Distance;
                }
            }
            return max;
        }
    }
}