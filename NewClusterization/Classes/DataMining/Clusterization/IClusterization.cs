namespace NewClusterization.Classes.DataMining.Clusterization
{
    /// <summary>
    /// ��������� ������� ������������� 
    /// </summary>
    public interface IClusterization
    {
        ClusterizationResult Clusterizate(int Clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}