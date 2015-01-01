namespace Clusterizator
{
    using System.Collections;

    using LibiadaCore.Core;

    /// <summary>
    /// The clusterization result.
    /// </summary>
    public class ClusterizationResult : IBaseObject
    {
        /// <summary>
        /// The clusters.
        /// </summary>
        public ArrayList Clusters = new ArrayList();

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        public double Quality { get; set; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var result = new ClusterizationResult
                { Quality = Quality, Clusters = (ArrayList)Clusters.Clone() };
            return result;
        }
    }
}
