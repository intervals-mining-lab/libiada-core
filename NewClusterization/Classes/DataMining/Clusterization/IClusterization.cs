namespace NewClusterization.Classes.DataMining.Clusterization
{
    /// <summary>
    /// Интерфейс методов кластеризации 
    /// </summary>
    public interface IClusterization
    {
        ClustarizationResult Clusterizate(int Clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int Clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}