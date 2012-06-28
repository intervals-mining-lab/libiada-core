namespace NewClusterization.Classes.DataMining.Clusterization
{
    /// <summary>
    /// Интерфейс методов кластеризации 
    /// </summary>
    public interface IClusterization
    {
        ClusterizationResult Clusterizate(int Clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}