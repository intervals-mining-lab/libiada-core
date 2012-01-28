using System;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Калькулятор, вычисляющий характеристику качества разбиения
    /// </summary>
    public static class FCalculator
    {
        public static double Calculate(GraphManager CurrentGraph, GraphManager SourceGraph, double powerWeight)
        {
            double F = Math.Pow(HCalculator.Calculate(CurrentGraph), powerWeight);
            for (int i = 0; i < CurrentGraph.Connections.Count; i++)
            {
                // H домножается на λ-расстояние разорванной связи
                if (CurrentGraph.Connections[i].Connected != SourceGraph.Connections[i].Connected)
                {
                    F *= CurrentGraph.Connections[i].λ;
                }
            }
            return F;
        }
    }
}