using System;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    /// <summary>
    /// �����������, ����������� �������������� �������� ���������
    /// </summary>
    public static class FCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentGraph"></param>
        /// <param name="sourceGraph"></param>
        /// <param name="powerWeight"></param>
        /// <returns></returns>
        public static double Calculate(GraphManager currentGraph, GraphManager sourceGraph, double powerWeight)
        {
            double F = Math.Pow(HCalculator.Calculate(currentGraph), powerWeight);
            for (int i = 0; i < currentGraph.Connections.Count; i++)
            {
                // H ����������� �� ������-���������� ����������� �����
                if (currentGraph.Connections[i].Connected != sourceGraph.Connections[i].Connected)
                {
                    F *= currentGraph.Connections[i].lambda;
                }
            }
            return F;
        }
    }
}