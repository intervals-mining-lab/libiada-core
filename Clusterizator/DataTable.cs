namespace Clusterizator
{
    using System.Collections;
    using System.Collections.Specialized;

    using LibiadaCore.Core;

    /// <summary>
    /// The data table.
    /// </summary>
    public class DataTable : IBaseObject, IEnumerable
    {
        /// <summary>
        /// The vault.
        /// </summary>
        private readonly HybridDictionary vault = new HybridDictionary();

        /// <summary>
        /// Gets the count.
        /// </summary>
        public long Count
        {
            get { return vault.Count; }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="DataObject"/>.
        /// </returns>
        public DataObject this[long s]
        {
            get { return (DataObject)vault[s]; }
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="object1">
        /// The object 1.
        /// </param>
        public void Add(DataObject object1)
        {
            vault.Add(object1.Id, object1);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var clone = new DataTable();

            foreach (var element in vault)
            {
                clone.Add((DataObject)element);
            }

            return clone;
        }
    }
}
