using Clusterizator.MeanShift;

namespace Clusterizator
{
    using System.Collections.Generic;
    using System.ComponentModel;

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
                    if (!parameters.TryGetValue("powerWeight",  out double powerWeight))
                    {
                        powerWeight = 1;
                    }

                    if (!parameters.TryGetValue("normalizedDistanceWeight", out double normalizedDistanceWeight))
                    {
                        normalizedDistanceWeight = 1;
                    }

                    if (!parameters.TryGetValue("distanceWeight", out double distanceWeight))
                    {
                        distanceWeight = 4;
                    }

                    return new KrabClusterization(powerWeight, normalizedDistanceWeight, distanceWeight);
                case ClusterizationType.MeanShift:
                    if (!parameters.TryGetValue("bandwidth", out double bandwidth))
                    {
                        bandwidth = 0;
                    }

                    if (!parameters.TryGetValue("dimension", out double dimension))
                    {
                        dimension = 0;
                    }

                    return new MeanShiftClusterization((int)dimension, bandwidth);
                default:
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(ClusterizationType));
            }
        }
    }
}
