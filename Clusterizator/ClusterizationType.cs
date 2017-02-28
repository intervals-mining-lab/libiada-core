using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clusterizator
{

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
        Krab = 2
    }
}
