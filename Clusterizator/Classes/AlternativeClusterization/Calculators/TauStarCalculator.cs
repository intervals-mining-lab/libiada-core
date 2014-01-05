using System;
using System.Collections.Generic;

namespace Clusterizator.Classes.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс для вычисления локальной плотности точек
    /// в окрестности данной пары точек
    /// </summary>
    public class TauStarCalculator : ICalculator
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
                Connection connection = graph.Connections[i];
                double bMin = GetBmin(graph.Connections, graph.Elements.Count,
                    connection.FirstElementIndex,
                    connection.SecondElementIndex);
                connection.TauStar = connection.Distance / bMin;
            }

        }

        /// <summary>
        /// Вычисляет минимальное расстояние до пары точек,
        /// т.е. ищет самое короткое ребро среди смежных данным точкам
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        /// <param name="elementsPower"> </param>
        /// <param name="firstElement">первая точка</param>
        /// <param name="secondElement">вторая точка</param>
        /// <returns>Bmin - минимальное расстояние</returns>
        private double GetBmin(List<Connection> graph, int elementsPower, int firstElement, int secondElement)
        {
            double min = Math.Min(SearchForMinimum(graph, elementsPower, firstElement, secondElement),
                SearchForMinimum(graph, elementsPower, secondElement, firstElement));
            return min;
        }

        private double SearchForMinimum(List<Connection> graph, int elementsPower, int element, int exceptedElement)
        {
            double min = double.MaxValue; //текущее минимальное расстояние

            int blockBegining = 0;
            for (int i = 0; i < element; i++)
            {
                blockBegining += BlockLength(i, elementsPower); //ищём начало нужного нам блока
            }

            int blockSum = 0; //сумма длин предыдущих блоков
            int shift = element - 1; //сдвиг внутри блока

            //цикл перебора отдельных значений в массиве пар вершин 
            for (int k = 0, j = element - 1; shift >= 0; j = blockSum + (--shift), k++)
            {
                if ((min > graph[j].Distance) && (graph[j].SecondElementIndex != exceptedElement) &&
                    (graph[j].FirstElementIndex != exceptedElement))
                {
                    min = graph[j].Distance;
                }
                blockSum += BlockLength(k, elementsPower);
            }

            int ourBlockLength = BlockLength(element, elementsPower); //вычисляем длину блока
            for (int k = blockBegining; k < blockBegining + ourBlockLength; k++) //перебор блока от начала до конца
            {
                if ((min > graph[k].Distance) && (graph[k].SecondElementIndex != exceptedElement) &&
                    (graph[k].FirstElementIndex != exceptedElement))
                {
                    min = graph[k].Distance;
                }
            }
            return min;
        }

        private int BlockLength(int element, int power)
        {
            return power - (element + 1);
        }
    }
}
