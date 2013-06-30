using System.Collections.Generic;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс для вычисления нормированного эвклидового расстояния 
    /// </summary>
    public class NormalizedLinearCalculator:ICalculator
    {
        /// <summary>
        /// Метод вычисляющий нормированное расстояние 
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public void Calculate(GraphManager graph)
        {
            double D = GetDiameter(graph.Connections);
            if(D == 0)
            {
                return;
            }
            //Ограничиваем диапазон расстояний в интервале (0;1]
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].NormalizedDistance = graph.Connections[i].Distance / D;  
            } 
        }

        /// <summary>
        /// Метод для нахождения диаметра графа
        /// (наибольшей дуги графа)
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        /// <returns>d - максимальное расстояние</returns>
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