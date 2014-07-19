namespace Clusterizator
{
    using System.Collections;

    using Clusterizator.Krab;

    using LibiadaCore.Core;

    /// <summary>
    /// The cluster.
    /// </summary>
    public class Cluster : IBaseObject
    {
        /// <summary>
        /// The items.
        /// </summary>
        public ArrayList Items = new ArrayList();

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        public Cluster(ArrayList points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Items.Add(((GraphElement)points[i]).Id);
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cluster"/> class from being created.
        /// </summary>
        private Cluster()
        {
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new Cluster { Items = (ArrayList)Items.Clone() };
            return clone;
        }
    }
}