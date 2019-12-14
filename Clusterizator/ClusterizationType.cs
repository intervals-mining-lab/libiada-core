namespace Clusterizator
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The clusterization type.
    /// </summary>
    public enum ClusterizationType : byte
    {
        /// <summary>
        /// The k means.
        /// </summary>
        [Display(Name = "K-means")]
        [Description("K-means clusterization")]
        KMeans = 1,

        /// <summary>
        /// The krab.
        /// </summary>
        [Display(Name = "KRAB clusterization")]
        [Description("KRAB clusterization")]
        Krab = 2,

        /// <summary>
        /// The mean shift.
        /// </summary>
        [Display(Name = "Mean shift")]
        [Description("Mean shift clusterization")]
        MeanShift = 3,

        /// <summary>
        /// The FRiS-Cluster.
        /// </summary>
        [Display(Name = "FRiS-Cluster")]
        [Description("FRiS-Cluster clusterization")]
        FRiSCluster = 4,

        [Display(Name = "KMeansMLNet")]
        [Description("KMeansMLNet clusterization")]
        KMeansMLNet = 5
    }
}
