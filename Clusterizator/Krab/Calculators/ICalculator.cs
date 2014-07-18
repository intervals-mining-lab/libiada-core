namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// Интерфейс калькулятора,
    /// реализуемый при расчётах кластеризации
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Метод реализует какое-либо вычисление для графа.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        void Calculate(GraphManager graph);

    }
}