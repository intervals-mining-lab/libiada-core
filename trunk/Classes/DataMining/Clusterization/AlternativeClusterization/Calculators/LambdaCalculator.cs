namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    ///<summary>
    /// Класс вычисляющий лямбда-расстояние для всех точек графа
    ///</summary>
    public class LambdaCalculator:ICalculator
    {

        /// <summary>
        /// Метод интерфейса ICalculator, 
        /// вычисляющий лямбда-расстояние
        /// </summary>
        /// <param name="graph">Массив связей графа</param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].λ = graph.Connections[i].tau * graph.Connections[i].tau * graph.Connections[i].distance;
            }
        }
    }
}