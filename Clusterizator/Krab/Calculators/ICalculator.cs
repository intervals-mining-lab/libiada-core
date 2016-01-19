namespace Clusterizator.Krab.Calculators
{
    /// <summary>
    /// Distance calculator interface.
    /// (used for clusterization)
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Distance calculation for the graph.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        void Calculate(GraphManager graph);
    }
}
