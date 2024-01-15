namespace Clusterizator.Krab.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// Calculator of local density of nodes.
    /// </summary>
    public class TauCalculator : ICalculator
    {
        /// <summary>
        /// Local density of nodes in neighborhood of given pair of nodes calculation method.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            double tauMax = GetTauStarMax(graph.Connections);
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                graph.Connections[i].Tau = graph.Connections[i].TauStar / tauMax;
            }
        }

        /// <summary>
        /// Maximum density calculation method.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        /// <returns>
        /// Tmax - maximum density of nodes in graph.
        /// </returns>
        private double GetTauStarMax(List<Connection> graph)
        {
            double result = 0;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].TauStar > result)
                {
                    result = graph[i].TauStar;
                }
            }

            return result;
        }
    }
}
