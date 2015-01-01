namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Класс для вычисления нормированного эвклидового расстояния 
    /// </summary>
    public class NormalizedLinearCalculator : ICalculator
    {
        /// <summary>
        /// Метод вычисляющий нормированное расстояние 
        /// </summary>
        /// <param name="graph">
        /// Массив связей графа.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            double diameter = GetDiameter(graph.Connections);
            if (Math.Abs(diameter - 0) < 0.00001)
            {
                return;
            }

            // Ограничиваем диапазон расстояний в интервале (0;1]
            foreach (Connection connection in graph.Connections)
            {
                connection.NormalizedDistance = connection.Distance / diameter;
            }
        }

        /// <summary>
        /// Метод для нахождения диаметра графа
        /// (наибольшей дуги графа)
        /// </summary>
        /// <param name="graph">
        /// Массив связей графа
        /// </param>
        /// <returns>
        /// d - максимальное расстояние
        /// </returns>
        private double GetDiameter(IEnumerable<Connection> graph)
        {
            return graph.Max(i => i.Distance);
        }
    }
}
