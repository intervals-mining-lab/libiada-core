namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// Статический класс-оболочка для всех калькуляторов
    /// </summary>
    public static class CommonCalculator
    {
        /// <summary>
        /// Вычисляет по очереди эвклидово расстояние, нормированное эвклидово расстояние,
        ///  локальную плотность точек, нормированную локальную плотность точек и лямбда-расстояние
        /// </summary>
        /// <param name="graph">
        /// Массив связей графа.
        /// </param>
        /// <param name="normalizedDistanceWeight">
        /// The normalized distance weight.
        /// </param>
        /// <param name="distanceWeight">
        /// The distance weight.
        /// </param>
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanceWeight, double distanceWeight)
        {
            ICalculator calc = new LinearCalculator();
            calc.Calculate(graph);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(graph);
            calc = new TauStarCalculator();
            calc.Calculate(graph);
            calc = new TauCalculator();
            calc.Calculate(graph);
            var lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(graph, normalizedDistanceWeight, distanceWeight);
        }
    }
}
