using System;
using System.Collections;

namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Класс для вычисления эвклидова расстояния
    /// </summary>
    public  class LinearCalculator:ICalculator
    {
        /// <summary>
        /// Метод интерфейса ICalculator
        /// вычисляюший эвклидово расстояние
        /// между всем объектами графа
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public  void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                double distance = 0;
                //Получаем энумераторы для перебора всех точек
                IDictionaryEnumerator firstCounter = graph.Elements[graph.Connections[i].FirstElementIndex].Content.GetEnumerator(); 
                firstCounter.Reset();
                //Переходим к начальным точкам
                firstCounter.MoveNext();
                for (int j = 0; j < graph.Elements[graph.Connections[i].FirstElementIndex].Content.Count; j++)
                {
                    double element = Convert.ToDouble(firstCounter.Value) - Convert.ToDouble(graph.Elements[graph.Connections[i].SecondElementIndex].Content[firstCounter.Key]);
                    distance += element*element;
                    firstCounter.MoveNext();
                }
                distance = Math.Sqrt(distance);
                graph.Connections[i].distance = distance;
            }
        }
    }
}