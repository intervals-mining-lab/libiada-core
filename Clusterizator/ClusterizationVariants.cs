using System.Collections;
using LibiadaCore.Core;

namespace Clusterizator
{
    /// <summary>
    /// The clusterization variants.
    /// </summary>
    public class ClusterizationVariants : IBaseObject
    {
        /// <summary>
        /// The variants.
        /// </summary>
        public ArrayList Variants = new ArrayList();

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var result = new ClusterizationVariants { Variants = (ArrayList)Variants.Clone() };
            return result;
        }
    }
}