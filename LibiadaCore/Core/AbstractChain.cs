namespace LibiadaCore.Core
{
    using System.Text;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The abstract chain.
    /// </summary>
    public abstract class AbstractChain : IBaseObject
    {
        /// <summary>
        /// Indexer. Returns element by index.
        /// </summary>
        /// <param name="index">
        /// Index of element.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject this[int index]
        {
            get
            {
                return Get(index);
            }

            set
            {
                Set(value, index);
            }
        }

        /// <summary>
        /// The length of chain.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public abstract int GetLength();

        /// <summary>
        /// Sets or replaces element in specified position.
        /// </summary>
        /// <param name="item">
        /// Element to set. 
        /// </param>
        /// <param name="index">
        /// Position in sequence.
        /// </param>
        public abstract void Set(IBaseObject item, int index);

        /// <summary>
        /// Gets element by index.
        /// Inner implementation of indexer.
        /// </summary>
        /// <param name="index">
        /// Index of element.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public abstract IBaseObject Get(int index);

        /// <summary>
        /// Removes element from given position.
        /// </summary>
        /// <param name="index">
        /// Index of deleted element.
        /// </param>
        public abstract void RemoveAt(int index);

        /// <summary>
        /// Deletes chain (building and alphabet) and creates new empty chain with given length.
        /// </summary>
        /// <param name="length">
        /// New chain length.
        /// </param>
        public abstract void ClearAndSetNewLength(int length);

        /// <summary>
        /// Creates clone of this chain.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public abstract IBaseObject Clone();

        /// <summary>
        /// Converts chain to string.
        /// Empty positions are filled with <see cref="NullValue"/> ('-' symbol).
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public new string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < GetLength(); i++)
            {
                builder.Append(this[i]);
            }

            return builder.ToString();
        }
    }
}