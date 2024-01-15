using Accord.MachineLearning;

namespace Clusterizator.kMeans
{
    /// <summary>
    /// The k means clusterization.
    /// </summary>
    public class KMeansClusterization : IClusterizator
    {
        /// <summary>
        /// The cluster.
        /// </summary>
        /// <param name="clustersCount">
        /// The clusters count.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="T:int[]"/>.
        /// </returns>
        public int[] Cluster(int clustersCount, double[][] data)
        {
            KMeans kMeans = new KMeans(clustersCount);

            var clusters = kMeans.Learn(data);
            var result = new int[data.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = clusters.Decide(data[i]);
            }

            return result;
        }
    }
}
