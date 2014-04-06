namespace Segmenter.Base.Collectors
{
    using System.Collections.Generic;

    using Segmenter.Base.Iterators;

    /// <summary>
    /// Contains a pairs of objects word and its positions
    /// </summary>
    public class DataCollector
    {
        private Dictionary<List<string>, List<int>> dictionary = new Dictionary<List<string>, List<int>>();

        public void Add(StartIterator iterator, int disp)
        {
            List<string> str = iterator.Current();
            int position = iterator.Position();
            this.Add(str, position, disp);
        }

        public void Add(List<string> accord, int position, int disp)
        {
            if (!this.dictionary.ContainsKey(accord))
            {
                this.dictionary.Add(accord, new List<int>());
            }

            this.dictionary[accord].Add(position + disp);
        }

        /// <summary>
        /// Возвращает список позиций указанной цепочки?
        /// </summary>
        /// <param name="chain">Цепочка?</param>
        /// <returns></returns>
        public List<int> Positions(List<string> chain)
        {
            return new List<int>(this.dictionary[chain]);
        }

        /// <summary>
        /// Возвращает все вхождения из списка
        /// </summary>
        /// <returns></returns>
        public Dictionary<List<string>, List<int>> Entry()
        {
            return new Dictionary<List<string>, List<int>>(this.dictionary);
        }
    }
}