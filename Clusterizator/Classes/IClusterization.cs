namespace Clusterizator.Classes
{
    /// <summary>
    /// Интерфейс методов кластеризации 
    /// </summary>
    public interface IClusterization
    {
        ClusterizationResult Clusterizate(int clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}