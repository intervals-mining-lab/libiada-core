using System;
using System.Collections.Generic;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
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
                graph.Connections[i].tauStar = graph.Connections[i].distance / GetBmin(graph.Connections, graph.Elements.Count, graph.Connections[i].FirstElementIndex, graph.Connections[i].SecondElementIndex);
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
        private double GetBmin(List<Connection> graph, int ElementsPower, int firstElement, int secondElement)
        {
             double min = Math.Min(SearchForMinimum(graph, ElementsPower, firstElement, secondElement),
                                  SearchForMinimum(graph, ElementsPower, secondElement, firstElement));
            return min;
        }

        private double SearchForMinimum(List<Connection> graph, int ElementsPower, int Element, int ExceptedElement)
        {
            double min = double.MaxValue;//текущее минимальное расстояние

            int BlockBegining = 0;
            for (int i = 0; i < Element; i++)
            {
                BlockBegining += BlockLength(i,ElementsPower);//ищём начало нужного нам блока
            }

            int blockSumm = 0;//сумма длин предыдущих блоков
            int shift = Element - 1; //сдвиг внутри блока

            //цикл перебора отдельных значений в массиве пар вершин 
            for (int k=0, j = Element - 1; shift >= 0; j = blockSumm + (--shift), k++)
            {
                if ((min > graph[j].distance) && (graph[j].SecondElementIndex != ExceptedElement) && (graph[j].FirstElementIndex != ExceptedElement))
                {
                    min = graph[j].distance;
                }
                blockSumm += BlockLength(k,ElementsPower);
            }

            int OurBlockLength = BlockLength(Element,ElementsPower);//вычисляем длину блока
            for (int k = BlockBegining; k < BlockBegining + OurBlockLength; k++)//перебор блока от начала до конца
            {
                if ((min > graph[k].distance) && (graph[k].SecondElementIndex != ExceptedElement) && (graph[k].FirstElementIndex != ExceptedElement))
                {
                    min = graph[k].distance;
                }
            }
            return min;
        }

        private int BlockLength(int Element, int Power)
        {
            return Power - (Element + 1);
        }
    }
}
