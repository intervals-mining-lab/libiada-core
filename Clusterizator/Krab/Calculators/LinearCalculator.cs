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
        /// Euclidean distance calculation mathod.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                double distance = 0;

                // enumerating through al nodes
                IDictionaryEnumerator firstCounter = graph.Elements[graph.Connections[i].FirstElementIndex].Content.GetEnumerator();
                firstCounter.Reset();
                firstCounter.MoveNext();
                for (int j = 0; j < graph.Elements[graph.Connections[i].FirstElementIndex].Content.Count; j++)
                {
                    double element = Convert.ToDouble(firstCounter.Value) -
                                     Convert.ToDouble(graph.Elements[graph.Connections[i].SecondElementIndex].Content[firstCounter.Key]);
                    distance += element * element;
                    firstCounter.MoveNext();
                }

                distance = Math.Sqrt(distance);
                graph.Connections[i].Distance = distance;
            }
        }
    }
}
