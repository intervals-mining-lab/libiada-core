using System.Collections.Generic;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс для вычисления нормированной локальной плотности точек
    /// в окрестности данной пары точек
    /// </summary>
    public class TauCalculator:ICalculator
    {

        /// <summary>
        /// Метод вычисляющий нормированную локальную плотность точек 
        /// в окрестности данной пары точек
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public void Calculate(GraphManager graph)
        {
            double tauMax = GetTauStarMax(graph.Connections);
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].tau = graph.Connections[i].tauStar / tauMax;
            }
        }

        /// <summary>
        /// Метод вычислияет максимальную плотность точек в графе
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        /// <returns>Tmax - максимальная плотность</returns>
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