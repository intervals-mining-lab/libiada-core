namespace Clusterizator
{
    using System.Collections;
    using System.Collections.Specialized;

    using LibiadaCore.Core;

    /// <summary>
    /// The data object.
    /// </summary>
    public class DataObject : IBaseObject, IEnumerable
    {
        /// <summary>
        /// The vault.
        /// </summary>
        public readonly HybridDictionary Vault = new HybridDictionary();

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="d">
        /// The d.
        /// </param>
        public void Add(string s, double d)
        {
            Vault.Add(s, d);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Get(string s)
        {
            return (double)Vault[s];
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return Vault.GetEnumerator();
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new DataObject();

            foreach (var key in Vault.Keys)
            {
                clone.Add(key.ToString(), Get(key.ToString()));
            }

            clone.Id = Id;

            return clone;
        }
    }
}
