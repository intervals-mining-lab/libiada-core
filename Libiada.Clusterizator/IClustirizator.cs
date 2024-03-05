namespace Libiada.Clusterizator;

/// <summary>
/// The Clusterizator interface.
/// </summary>
public interface IClusterizator
{
    /// <summary>
    /// The cluster.
    /// </summary>
    /// <param name="clustersCount">
    /// The clusters count.
    /// </param>
    /// <param name="data">
    /// The data.
    /// </param>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    int[] Cluster(int clustersCount, double[][] data);
}
