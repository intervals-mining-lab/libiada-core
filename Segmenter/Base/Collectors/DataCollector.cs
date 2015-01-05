namespace Segmenter.Base.Collectors
{
    using System.Collections.Generic;

    using Segmenter.Base.Iterators;

    /// <summary>
    /// Contains a pairs of objects word and its positions.
    /// </summary>
    public class DataCollector
    {
        /// <summary>
        /// The dictionary.
        /// </summary>
        private Dictionary<List<string>, List<int>> dictionary = new Dictionary<List<string>, List<int>>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="iterator">
        /// The iterator.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        public void Add(StartIterator iterator, int step)
        {
            List<string> str = iterator.Current();
            int position = iterator.Position();
            Add(str, position, step);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="accord">
        /// The accord.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        public void Add(List<string> accord, int position, int step)
        {
            if (!dictionary.ContainsKey(accord))
            {
                dictionary.Add(accord, new List<int>());
            }

            dictionary[accord].Add(position + step);
        }

        /// <summary>
        /// Возвращает список позиций указанной цепочки?
        /// </summary>
        /// <param name="chain">
        /// Цепочка?
        /// </param>
        /// <returns>
        /// The <see cref="List{Int32}"/>.
        /// </returns>
        public List<int> Positions(List<string> chain)
        {
            return new List<int>(dictionary[chain]);
        }

        /// <summary>
        /// Возвращает все вхождения из списка.
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        public Dictionary<List<string>, List<int>> Entry()
        {
            return new Dictionary<List<string>, List<int>>(dictionary);
        }
    }
}
