namespace NewClusterization.Classes.DataMining.Clusterization
{
    /// <summary>
    /// ��������� ������� ������������� 
    /// </summary>
    public interface IClusterization
    {
        ClustarizationResult Clusterizate(int Clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int Clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}