using System;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Калькулятор, вычисляющий характеристику качества разбиения
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
                // H домножается на лямбда-расстояние разорванной связи
                if (currentGraph.Connections[i].Connected != sourceGraph.Connections[i].Connected)
                {
                    F *= currentGraph.Connections[i].lambda;
                }
            }
            return F;
        }
    }
}