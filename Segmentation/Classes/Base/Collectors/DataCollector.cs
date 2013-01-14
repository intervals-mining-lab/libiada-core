using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Iterators;

namespace Segmentation.Classes.Base.Collectors
{
    /// <summary>
    /// Contains a pairs of objects word and its positions
    /// </summary>
    public class DataCollector
    {
        private Dictionary<List<String>, List<int>> dictionary = new Dictionary<List<String>, List<int>>();


        public void Add(StartIterator iterator, int disp)
        {
            List<String> str = iterator.Current();
            int position = iterator.Position();
            Add(str, position, disp);
        }

        public void Add(List<String> accord, int position, int disp)
        {
            if (!dictionary.ContainsKey(accord))
            {
                dictionary.Add(accord, new List<int>());
            }
            dictionary[accord].Add(position + disp);
        }

        /// <summary>
        /// Возвращает список позиций указанной цепочки?
        /// </summary>
        /// <param name="chain">Цепочка?</param>
        /// <returns></returns>
        public List<int> Positions(List<String> chain)
        {
            return new List<int>(dictionary[chain]);
        }

        /// <summary>
        /// Возвращает все вхождения из списка
        /// </summary>
        /// <returns></returns>
        public Dictionary<List<String>, List<int>> Entry()
        {
            return new Dictionary<List<string>, List<int>>(dictionary);
        }
    }
}