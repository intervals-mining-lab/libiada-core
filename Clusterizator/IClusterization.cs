namespace Clusterizator
{
    /// <summary>
    /// Интерфейс методов кластеризации 
    /// </summary>
    public interface IClusterization
    {
        /// <summary>
        /// The clusterizate.
        /// </summary>
        /// <param name="clusters">
        /// The clusters.
        /// </param>
        /// <returns>
        /// The <see cref="ClusterizationResult"/>.
        /// </returns>
        ClusterizationResult Clusterizate(int clusters);

        /// <summary>
        /// The clusterizate variant count clusters below.
        /// </summary>
        /// <param name="clusters">
        /// The clusters.
        /// </param>
        /// <returns>
        /// The <see cref="ClusterizationVariants"/>.
        /// </returns>
        ClusterizationVariants ClusterizateVariantCountClustersBelow(int clusters);

        /// <summary>
        /// The clusterizate all variants.
        /// </summary>
        /// <returns>
        /// The <see cref="ClusterizationVariants"/>.
        /// </returns>
        ClusterizationVariants ClusterizateAllVariants();
    }
}