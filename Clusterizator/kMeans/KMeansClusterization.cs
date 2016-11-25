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

            return kmeans.Compute(data);
        }
    }
}
