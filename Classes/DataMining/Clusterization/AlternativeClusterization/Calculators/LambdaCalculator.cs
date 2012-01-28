using System;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    ///<summary>
    /// Класс вычисляющий лямбда-расстояние для всех точек графа
    ///</summary>
    public class LambdaCalculator
    {

        /// <summary>
        /// Метод интерфейса ICalculator, 
        /// вычисляющий лямбда-расстояние
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public void Calculate(GraphManager graph, double normalizedDistanseWeight, double distanseWeight)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].λ = Math.Pow(graph.Connections[i].tau, normalizedDistanseWeight) * Math.Pow(graph.Connections[i].distance, distanseWeight);
            }
        }
    }
}