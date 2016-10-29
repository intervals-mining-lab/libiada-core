namespace Clusterizator.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Calculator of local density of nodes.
    /// </summary>
    public class TauStarCalculator : ICalculator
    {
        /// <summary>
        /// Local density of nodes in neighborhood of given pair of nodes calculation method.
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        public void Calculate(GraphManager graph)
        {
            for (int i = 0; i < graph.Connections.Count; i++)
            {
                Connection connection = graph.Connections[i];
                double bMinimum = GetBMinimum(graph.Connections, graph.Elements.Count, connection.FirstElementIndex, connection.SecondElementIndex);
                connection.TauStar = connection.Distance / bMinimum;
            }
        }

        /// <summary>
        /// Calculates minimal distance to the nodes pair
        /// (searches for the shortest adjacent connection).
        /// </summary>
        /// <param name="graph">
        /// Connections graph.
        /// </param>
        /// <param name="elementsPower">
        /// Count of elements.
        /// </param>
        /// <param name="firstElement">
        /// First node.
        /// </param>
        /// <param name="secondElement">
        /// Second node.
        /// </param>
        /// <returns>
        /// Bminimum - minimal distance.
        /// </returns>
        private double GetBMinimum(List<Connection> graph, int elementsPower, int firstElement, int secondElement)
        {
            double min = Math.Min(
                SearchForMinimum(graph, elementsPower, firstElement, secondElement),
                SearchForMinimum(graph, elementsPower, secondElement, firstElement));
            return min;
        }

        /// <summary>
        /// The search for minimum.
        /// </summary>
        /// <param name="graph">
        /// The graph.
        /// </param>
        /// <param name="elementsPower">
        /// The elements power.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="exceptedElement">
        /// The excepted element.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double SearchForMinimum(List<Connection> graph, int elementsPower, int element, int exceptedElement)
        {
            // current minimum distance
            double min = double.MaxValue;

            int blockBeginning = 0;
            for (int i = 0; i < element; i++)
            {
                // searching start ofrequired block
                blockBeginning += BlockLength(i, elementsPower);
            }

            // sum of previous blocks lengthes
            int blockSum = 0;

            // shift inside block
            int shift = element - 1;

            // cycling through separate values in array of connections (pairs of nodes)
            for (int k = 0, j = element - 1; shift >= 0; j = blockSum + (--shift), k++)
            {
                if ((min > graph[j].Distance) &&
                    (graph[j].SecondElementIndex != exceptedElement) &&
                    (graph[j].FirstElementIndex != exceptedElement))
                {
                    min = graph[j].Distance;
                }

                blockSum += BlockLength(k, elementsPower);
            }

            // calculating block length
            int ourBlockLength = BlockLength(element, elementsPower);

            // iterating block from start to the end
            for (int k = blockBeginning; k < blockBeginning + ourBlockLength; k++)
            {
                if ((min > graph[k].Distance) &&
                    (graph[k].SecondElementIndex != exceptedElement) &&
                    (graph[k].FirstElementIndex != exceptedElement))
                {
                    min = graph[k].Distance;
                }
            }

            return min;
        }

        /// <summary>
        /// The block length.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="power">
        /// The power.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int BlockLength(int element, int power)
        {
            return power - (element + 1);
        }
    }
}
