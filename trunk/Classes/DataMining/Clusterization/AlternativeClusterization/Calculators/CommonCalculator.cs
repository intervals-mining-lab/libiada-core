namespace ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators
{
    ///<summary>
    /// Статический класс-оболочка для всех калькуляторов
    ///</summary>
    public static class CommonCalculator
    {
        /// <summary>
        /// Вычисляет по очереди эвклидово расстояние, нормированное эвклидово расстояние,
        ///  локальную плотность точек, нормированную локальную плотность точек и лямбда-расстояние
        /// </summary>
        /// <param name="graph"> Массив связей графа</param>
        public static void CalculateCharacteristic(GraphManager graph, double normalizedDistanseWeight, double distanseWeight)
        {
            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(graph);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(graph);
            Calc = new TauStarCalculator();
            Calc.Calculate(graph);
            Calc = new TauCalculator();
            Calc.Calculate(graph);
            LambdaCalculator lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(graph,normalizedDistanseWeight, distanseWeight);
        }
    }
}