using System;
using System.Collections.Generic;

namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    ///  ласс дл€ вычислени€ локальной плотности точек
    /// в окрестности данной пары точек
    /// </summary>
    public class TauStarCalculator:ICalculator 
    {
        /// <summary>
        /// ћетод вычисл€ющий локальную плотность точек 
        /// в окрестности данной пары точек
        /// </summary>
        /// <param name="graph">ћассив св€зей графа</param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].tauStar = graph.Connections[i].distance/GetBmin(graph.Connections,graph.Connections[i].FirstElementIndex, graph.Connections[i].SecondElementIndex);
            }
           
        }

        /// <summary>
        /// ¬ычисл€ет минимальное рассто€ние до пары точек,
        /// т.е. ищет самое короткое ребро среди смежных данным точкам
        /// </summary>
        /// <param name="graph">ћассив св€зей графа</param>
        /// <param name="firstElement">перва€ точка</param>
        /// <param name="secondElement">втора€ точка</param>
        /// <returns>Bmin - минимальное рассто€ние</returns>
        private double GetBmin(List<Connection> graph,int firstElement,int secondElement)
        {
            double min = Math.Min(SearchForMinimum(graph, firstElement, secondElement),
                                  SearchForMinimum(graph, secondElement, firstElement));
            return min;
        }

        private double SearchForMinimum(List<Connection> graph,int Element,int ExceptedElement)
        {
            double min = double.MaxValue;//текущее минимальное рассто€ние

            int BlockBegining = 0;
            for (int i = 0; i < Element; i++)
            {
                int blockLength = graph.Count - (i + 1);//graph.Count - мощность алфавита 
                                                        //вычисл€ем длину блока, где на первом месте стоит один и тот же элемент
                BlockBegining += blockLength;//ищЄм начало нужного нам блока
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
                blockSumm += graph.Count - (k + 1);
            }

            int OurBlockLength = graph.Count - (Element + 1);//вычисл€ем длину блока
            for (int k = BlockBegining; k < BlockBegining + OurBlockLength; k++)//перебор блока от начала до конца
            {
                if ((min > graph[k].distance) && (graph[k].SecondElementIndex != ExceptedElement) && (graph[k].FirstElementIndex != ExceptedElement))
                {
                    min = graph[k].distance;
                }
            }
            return min;
        }
    }
}
