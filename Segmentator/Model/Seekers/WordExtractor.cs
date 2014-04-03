namespace Segmentator.Model.Seekers
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core.SimpleTypes;

    using Segmentator.Base.Collectors;
    using Segmentator.Extended;

    /// <summary>
    /// Used as a base for all kinds of word seekers for a chain
    /// </summary>
    public abstract class WordExtractor
    {
        protected Dictionary<Double, KeyValuePair<List<String>, List<int>>> WordPriority =
            new Dictionary<Double, KeyValuePair<List<String>, List<int>>>();

        protected DataCollector FullEntry = new DataCollector();

        /// <summary>
        /// Finds a word based on current parameters
        /// </summary>
        /// <param name="par">current segmentation parameters</param>
        /// <returns></returns>
        public abstract KeyValuePair<List<string>, List<int>>? Find(ContentValues par);

        /// <summary>
        /// Discards all words which enter in the alphabet and contains compound words
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="level">filtrate level</param>
        /// <returns></returns>
        protected KeyValuePair<List<string>, List<int>>? DiscardCompositeWords(FrequencyDictionary alphabet, double level)
        {
            List<Double> stds = new List<Double>(this.WordPriority.Keys);
            List<KeyValuePair<List<String>, List<int>>> entries =
                new List<KeyValuePair<List<String>, List<int>>>(this.WordPriority.Values);
            for (int index = entries.Count; --index >= 0;)
            {
                List<String> entry = entries[index].Key;
                String entryS;
                if (!alphabet.Contains(new ValueString(entryS = Helper.ToString(entry))) && (entry.Count == entryS.Length))
                {
                    double bestStd = stds[index];
                    if (bestStd > level)
                    {
                        return new KeyValuePair<List<string>, List<int>>(this.WordPriority[bestStd].Key, this.WordPriority[bestStd].Value);
                    }
                }
            }
            return null;
        }
    }
}