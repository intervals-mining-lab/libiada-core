using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;

namespace Clusterizator.kMeans
{
    public class KMeansClusterization
    {
        public int[] Cluster(int clustersCount, double[][] data)
        {
            KMeans kmeans = new KMeans(clustersCount);

            var clusters = kmeans.Learn(data);
            var result = new int[data.Length];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = clusters.Decide(data[i]);
            }

            return result;
        }
    }
}
