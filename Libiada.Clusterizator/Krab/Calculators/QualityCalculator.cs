namespace Libiada.Clusterizator.Krab.Calculators;

/// <summary>
/// Clusterization quality calculator.
/// </summary>
public static class QualityCalculator
{
    /// <summary>
    /// The calculate.
    /// </summary>
    /// <param name="currentGraph">
    /// The current graph.
    /// </param>
    /// <param name="sourceGraph">
    /// The source graph.
    /// </param>
    /// <param name="powerWeight">
    /// The power weight.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public static double Calculate(GraphManager currentGraph, GraphManager sourceGraph, double powerWeight)
    {
        double quality = Math.Pow(EquipotencyCalculator.Calculate(currentGraph), powerWeight);
        for (int i = 0; i < currentGraph.Connections.Count; i++)
        {
            // H is multiplied by lambda-distance of disconnected link
            if (currentGraph.Connections[i].Connected != sourceGraph.Connections[i].Connected)
            {
                quality *= currentGraph.Connections[i].Lambda;
            }
        }

        return quality;
    }
}
