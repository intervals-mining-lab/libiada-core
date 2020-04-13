using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.AffinityPropagation
{
    public class AffinityPropagation : IClusterizator
    {
        public int[] Cluster(int clustersCount, double[][] data)
        {
            var dataToCluster = new APClusteringData(data);
            for(int i = 0; i < dataToCluster.IterationCount; i++)
            {
                dataToCluster.UpdateResponsibility();
                dataToCluster.UpdateAvailibility();
                dataToCluster.UpdateCombined();
            }
            return dataToCluster.FindExamplars();
        }
    }
}
