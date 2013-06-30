namespace Clusterizator.Classes
{
    /// <summary>
    /// ��������� ������� ������������� 
    /// </summary>
    public interface IClusterization
    {
        ClusterizationResult Clusterizate(int clusters);
        ClustarizationVariants ClusterizateVariantCountClustersBelow(int clusters);
        ClustarizationVariants ClusterizateAllVariants();
    }
}