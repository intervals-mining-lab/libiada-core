using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clusterizator.kMeans;
using Clusterizator.Krab;

namespace Clusterizator
{
    public static class ClusterizatorsFactory
    {
        public static IClusterizator CreateClusterization(ClusterizationType type, Dictionary<string, double> parameters)
        {
            switch(type)
            {
                case ClusterizationType.kMeans: 
                    return new KMeansClusterization();
                case ClusterizationType.Krab:
                    double powerWeight;
                    if(!parameters.TryGetValue("powerWeight", out powerWeight))
                    {
                        powerWeight = 1;
                    }

                    double normalizedDistanceWeight;
                    if (!parameters.TryGetValue("normalizedDistanceWeight", out normalizedDistanceWeight))
                    {
                        normalizedDistanceWeight = 1;
                    }

                    double distanceWeight;
                    if (!parameters.TryGetValue("distanceWeight", out distanceWeight))
                    {
                        distanceWeight = 4;
                    }

                    return new KrabClusterization(powerWeight, normalizedDistanceWeight, distanceWeight);
                default:
                    throw new Exception();
            }
        }
    }
}
