namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// Static wrap-class for distance calculations.
    /// </summary>
    public static class CommonCalculator
    {
        /// <summary>
        /// Вычисляет по очереди эвклидово расстояние, нормированное эвклидово расстояние,
        ///  локальную плотность точек, нормированную локальную плотность точек и лямбда-расстояние
        /// </summary>
        /// <param name="graph">
        /// Array of graph links.
        /// </param>
        /// <param name="normalizedDistanceWeight">
        /// The normalized distance weight.
        /// </param>
        /// <param name="distanceWeight">
        /// The distance weight.
        /// </param>
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanceWeight, double distanceWeight)
        {
            ICalculator calculator = new LinearCalculator();
            calculator.Calculate(graph);
            calculator = new NormalizedLinearCalculator();
            calculator.Calculate(graph);
            calculator = new TauStarCalculator();
            calculator.Calculate(graph);
            calculator = new TauCalculator();
            calculator.Calculate(graph);
            var lambdaCalculator = new LambdaCalculator();
            lambdaCalculator.Calculate(graph, normalizedDistanceWeight, distanceWeight);
        }
    }
}
