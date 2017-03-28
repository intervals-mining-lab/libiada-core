using Clusterizator.MeanShift;

namespace Clusterizator
{
    using System;
    using System.Collections.Generic;

    using Clusterizator.KMeans;
    using Clusterizator.Krab;

    /// <summary>
    /// The clusterizators factory.
    /// </summary>
    public static class ClusterizatorsFactory
    {
        /// <summary>
        /// The create clusterizator.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IClusterizator"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if culsterizator type is invalid
        /// </exception>
        public static IClusterizator CreateClusterizator(ClusterizationType type, Dictionary<string, double> parameters)
        {
            switch (type)
            {
                case ClusterizationType.KMeans:
                    return new KMeansClusterization();
                case ClusterizationType.Krab:
                    double powerWeight;
                    if (!parameters.TryGetValue("powerWeight", out powerWeight))
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
                case ClusterizationType.MeanShift:
                    double bandwidth;
                    if (!parameters.TryGetValue("bandwidth", out bandwidth))
                    {
                        bandwidth = 0;
                    }

                    double dimension;
                    if (!parameters.TryGetValue("dimension", out dimension))
                    {
                        dimension = 0;
                    }
                    return new MeanShiftClusterization((int) dimension, bandwidth);
                default:
                    throw new Exception("Unknown clusterization type");
            }
        }
    }
}
