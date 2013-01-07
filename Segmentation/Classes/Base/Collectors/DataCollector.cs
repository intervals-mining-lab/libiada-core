using System;
using System.Collections.Generic;
using Segmentation.Classes.Base.Iterators;

namespace Segmentation.Classes.Base.Collectors
{
    /// <summary>
    /// Contains a pair of objects word and its positions
    /// </summary>
    public class DataCollector
    {
        private Dictionary<List<String>, List<int>> dictionary = new Dictionary<List<String>, List<int>>();


        public void add(StartIterator iterator, int disp)
        {
            List<String> str = iterator.current();
            int position = iterator.position();
            add(str, position, disp);
        }

        public void add(List<String> accord, int position, int disp)
        {
            if (!dictionary.ContainsKey(accord))
            {
                dictionary.Add(accord, new List<int>());
            }
            dictionary[accord].Add(position + disp);
        }

        public int size()
        {
            return dictionary.Count;
        }

        public List<int> positions(List<String> chain)
        {
            return dictionary[chain];
        }


        public Dictionary<List<String>, List<int>> entrySet()
        {
            return dictionary;
        }

        public Dictionary<List<String>, List<int>> entry()
        {
            return dictionary;
        }
    }
}