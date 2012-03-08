namespace NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    /// <summary>
    /// Интерфейс калькулятора,
    /// реализуемый при расчётах кластеризации
    /// </summary>
    public interface ICalculator
    {
        ///<summary>
        /// Метод реализует какое-либо вычисление для графа.
        ///</summary>
        ///<param name="graph">Граф</param>
        void Calculate(GraphManager graph);

    }
}