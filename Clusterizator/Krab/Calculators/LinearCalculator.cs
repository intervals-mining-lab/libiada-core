namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections;

    /// <summary>
    /// Euclidean distance calculator.
    /// </summary>
    public class LinearCalculator : ICalculator
    {
        /// <summary>
        /// Euclidean distance calculation method.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                double distance = 0;

                for (int j = 0; j < graph.Elements[graph.Connections[i].FirstElementIndex].Content.Length; j++)
                {
                    double substriction = graph.Elements[graph.Connections[i].FirstElementIndex].Content[j] -
                                     graph.Elements[graph.Connections[i].SecondElementIndex].Content[j];

                    distance += substriction * substriction;
                }

                distance = Math.Sqrt(distance);
                graph.Connections[i].Distance = distance;
            }
        }
    }
}
