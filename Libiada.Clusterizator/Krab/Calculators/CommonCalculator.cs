namespace Libiada.Clusterizator.Krab.Calculators;

/// <summary>
/// Static wrap-class for distance calculations.
/// </summary>
public static class CommonCalculator
{
    /// <summary>
    /// Calculates euclidean distance, normalized euclidean distance, local nodes density,
    /// normalized local nodes density and lambda-distance.
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
        LambdaCalculator lambdaCalculator = new();
        lambdaCalculator.Calculate(graph, normalizedDistanceWeight, distanceWeight);
    }
}
