using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс для вычисления локальной плотности точек
    /// в окрестности данной пары точек
    /// </summary>
    public class TauStarCalculator:ICalculator 
    {
        /// <summary>
        /// Метод вычисляющий локальную плотность точек 
        /// в окрестности данной пары точек
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].tauStar = graph.Connections[i].distance/GetBmin(graph.Connections,graph.Connections[i].FirstElementIndex, graph.Connections[i].SecondElementIndex);
            }
           
        }

        /// <summary>
        /// Вычисляет минимальное расстояние до пары точек,
        /// т.е. ищет самое короткое ребро среди смежных данным точкам
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        /// <param name="firstElement">первая точка</param>
        /// <param name="secondElement">вторая точка</param>
        /// <returns>Bmin - минимальное расстояние</returns>
        private double GetBmin(List<Connection> graph,int firstElement,int secondElement)
        {
            double min=double.MaxValue;
            for (int i = 0; i < graph.Count; i++)
            {
                bool FirstFirst = graph[i].FirstElementIndex == firstElement;
                bool FirstSecond = graph[i].FirstElementIndex == secondElement;
                bool SecondFirst = graph[i].SecondElementIndex == firstElement;
                bool SecondSecond = graph[i].SecondElementIndex == secondElement;
                //проверяем есть ли в паре хотя бы одна из переданых точек 
                //и что пара не содержит обе точки одновременно
                if (((FirstFirst)||(FirstSecond)||(SecondFirst)||(SecondSecond))&&!((FirstFirst)&&(SecondSecond))&&!((SecondFirst)&&(FirstSecond)))
                {
                    if (min > graph[i].distance)
                    {
                        min = graph[i].distance;
                    } 
                }   
            }
            return min;
        }
    }
}