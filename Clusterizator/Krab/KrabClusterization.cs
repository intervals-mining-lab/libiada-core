namespace Clusterizator.Krab
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Clusterizator.Krab.Calculators;

    /// <summary>
    /// KRAB clusterization class.
    /// </summary>
    public class KrabClusterization : IClusterization
    {
        /// <summary>
        /// The power weight.
        /// </summary>
        private readonly double powerWeight;

        /// <summary>
        /// The manager.
        /// </summary>
        private GraphManager manager;

        /// <summary>
        /// The optimal divide.
        /// </summary>
        private GraphManager optimalDivide;

        /// <summary>
        /// The optimal f.
        /// </summary>
        private double optimalF;

        /// <summary>
        /// Initializes a new instance of the <see cref="KrabClusterization"/> class.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <param name="powerWeight">
        /// The power weight.
        /// </param>
        /// <param name="normalizedDistanceWeight">
        /// The normalized distance weight.
        /// </param>
        /// <param name="distanceWeight">
        /// The distance weight.
        /// </param>
        public KrabClusterization(DataTable dataTable, double powerWeight, double normalizedDistanceWeight, double distanceWeight)
        {
            // all connections (pairs of elements)
            var connections = new List<Connection>();

            // all elements
            var elements = new List<GraphElement>();

            this.powerWeight = powerWeight;

            IEnumerator counter = dataTable.GetEnumerator();
            counter.Reset();
            counter.MoveNext();
            for (int i = 0; i < dataTable.Count; i++)
            {
                var current = (DictionaryEntry)counter.Current;

                elements.Add(new GraphElement(((DataObject)current.Value).Vault, current.Key));

                // moving to the next element
                counter.MoveNext();
            }

            for (int j = 0; j < elements.Count - 1; j++)
            {
                for (int k = j + 1; k < elements.Count; k++)
                {
                    connections.Add(new Connection(j, k));
                }
            }

            manager = new GraphManager(connections, elements);

            // calculating distances
            CommonCalculator.CalculateCharacteristic(manager, normalizedDistanceWeight, distanceWeight);
            manager.ConnectGraph();
        }

        /// <summary>
        /// Clusterization method for given groups number.
        /// </summary>
        /// <param name="clustersCount">
        /// Groups count.
        /// </param>
        /// <returns>
        /// Optimal clusterization as <see cref="ClusterizationVariants"/>.
        /// </returns>
        public ClusterizationResult Cluster(int clustersCount)
        {
            GraphManager tempManager = manager.Clone();
            ChooseDivision(clustersCount, 0, manager);
            var result = new ClusterizationResult();
            var tempResult = new List<ArrayList>();
            for (int i = 0; i < optimalDivide.GetNextTaxonNumber(); i++)
            {
                tempResult.Add(new ArrayList());
            }

            // extracting clusters from the graph
            foreach (GraphElement element in this.optimalDivide.Elements)
            {
                tempResult[element.TaxonNumber].Add(element);
            }

            // saving only not empty groups
            tempResult = tempResult.Where(t => t.Count > 0).ToList();

            // adding groups to the result container
            foreach (ArrayList cluster in tempResult)
            {
                result.Clusters.Add(new Cluster(cluster));
            }

            manager = tempManager;
            return result;
        }

        /// <summary>
        /// Clusterization method for given or less nuber of groups.
        /// </summary>
        /// <param name="MaximumClustersCount">
        /// Maximum groups count.
        /// </param>
        /// <returns>
        /// Clustering result as <see cref="ClusterizationVariants"/>.
        /// </returns>
        public ClusterizationVariants ClusterVariantCountClustersBelow(int MaximumClustersCount)
        {
            var temp = new ClusterizationVariants();
            for (int i = 2; i <= MaximumClustersCount; i++)
            {
                temp.Variants.Add(Cluster(i));
            }

            return temp;
        }

        /// <summary>
        /// Dividing into all possible divisions.
        /// </summary>
        /// <returns>
        /// Clustering result as <see cref="ClusterizationVariants"/>.
        /// </returns>
        public ClusterizationVariants ClusterAllVariants()
        {
            return ClusterVariantCountClustersBelow(manager.Elements.Count);
        }

        /// <summary>
        /// Recursive method for finding optimal division of graph into clusters (groups).
        /// </summary>
        /// <param name="clusters">
        /// Clusters left to separate.
        /// </param>
        /// <param name="position">
        /// Starting position for iteration.
        /// </param>
        /// <param name="currentManager">
        /// Graph and its manager.
        /// </param>
        private void ChooseDivision(int clusters, int position, GraphManager currentManager)
        {
            // if recursive calls are required
            if (clusters > 1)
            {
                for (int i = position; i < (manager.Connections.Count - clusters); i++)
                {
                    // creatingcopy of graph to be able to disconnect pair of nodes (cut the link)
                    GraphManager tempManager = currentManager.Clone();
                    if (tempManager.Connections[i].Connected)
                    {
                        tempManager.Cut(tempManager.Connections[i]);
                        ChooseDivision(clusters - 1, i + 1, tempManager);
                    }
                }
            }
            else
            {
                // calculating clusterization quality
                double f = QualityCalculator.Calculate(currentManager, manager, powerWeight);
                if (f > optimalF)
                {
                    // saving optimal clusterization
                    optimalDivide = currentManager;
                    optimalF = f;
                }
            }
        }
    }
}
