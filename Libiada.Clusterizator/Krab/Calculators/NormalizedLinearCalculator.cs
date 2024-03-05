namespace Libiada.Clusterizator.Krab.Calculators;

/// <summary>
/// Normalized euclidean distance calculator.
/// </summary>
public class NormalizedLinearCalculator : ICalculator
{
    /// <summary>
    /// Normalized euclidean distance calculation method.
    /// </summary>
    /// <param name="graph">
    /// Connections graph.
    /// </param>
    public void Calculate(GraphManager graph)
    {
        double diameter = GetDiameter(graph.Connections);
        if (Math.Abs(diameter - 0) < 0.00001)
        {
            return;
        }

        // Normalizing all distances to range (0;1]
        foreach (Connection connection in graph.Connections)
        {
            connection.NormalizedDistance = connection.Distance / diameter;
        }
    }

    /// <summary>
    /// Graph diameter calculation method.
    /// Calculated as longest connection in graph
    /// </summary>
    /// <param name="graph">
    /// Connections graph.
    /// </param>
    /// <returns>
    /// d - maximum distance.
    /// </returns>
    private double GetDiameter(IEnumerable<Connection> graph)
    {
        return graph.Max(i => i.Distance);
    }
}
